using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CandyStack.Models.DTO;
using CandyStack.Models.Domain;
using ServiceStack.Common.Web;
using ServiceStack.MiniProfiler;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Cors;

namespace CandyStack.Server.Api
{
	public class CandyService : Service
	{
		public Candy Get(Candy request)
		{
			if (request == null)
				throw new ArgumentNullException("request");

			var currentProfiler = Profiler.Current;

			if (request.Id != default(uint))
			{
				using (currentProfiler.Step(string.Format("Looking for candy with Id: {0}", request.Id)))
				{
					var cacheKey = base.Request.PathInfo;

					using (currentProfiler.Step("Doing cache lookup for candy"))
					{
						var cacheItem = Cache.Get<Candy>(cacheKey);

						if (cacheItem != null)
							return cacheItem;
					}

					using (currentProfiler.Step("Doing db lookup for candy"))
					{
						var candy = Db.GetById<Candy>(request.Id);

						Cache.Add(cacheKey, candy);

						return candy;
					}
				}
			}

			throw new ArgumentException("No candy matching Id");
		}

		public List<Candy> Get(CandyRequest request)
		{
			if (request.Ids != null && request.Ids.Any())
			{
				var candies = Db.GetByIds<Candy>(request.Ids);

				return candies;
			}

			if (request.MinPrice.HasValue || request.MaxPrice.HasValue)
				return SearchByPrice(request.MinPrice, request.MaxPrice);

			return Db.Select<Candy>();
		}

		public Candy Post(Candy request)
		{
			if (request.Id != default(uint))
				throw new ArgumentException("Can not insert candy with existing id");

			Db.Insert(request);

			var id = Db.GetLastInsertId();

			request.Id = Convert.ToUInt16(id);

			return request;
		}

		public object Put(Candy request)
		{
			if (request.Id == default(uint))
				return new HttpResult(HttpStatusCode.BadRequest, "Candy must have an Id to be able to update it");

			Db.Save(request);

			return request;
		}

		public object Delete(Candy request)
		{
			if (request.Id == default(uint))
				throw new ArgumentException("Missing Id on the request, can't delete without an Id");

			Db.DeleteById<Candy>(request.Id);

			return new HttpResult(HttpStatusCode.OK);
		}

		public Candy Patch(UpdateCandy request)
		{
			Db.Update(request, c => c.Id == request.Id);

			return Db.GetById<Candy>(request.Id);
		}

		[EnableCors]
		public void Options(Candy request)
		{
		}

		private List<Candy> SearchByPrice(decimal? minPrice, decimal? maxPrice)
		{
			if (minPrice.HasValue && maxPrice.HasValue)
				return Db.Select<Candy>(c => c.Price >= minPrice.Value && c.Price <= maxPrice.Value);

			return minPrice.HasValue
				       ? Db.Select<Candy>(c => c.Price >= minPrice.Value)
				       : Db.Select<Candy>(c => c.Price <= maxPrice.Value);
		}
	}
}