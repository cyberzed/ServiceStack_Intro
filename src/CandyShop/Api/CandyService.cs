using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CandyStack.DTO;
using CandyStack.Domain;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace CandyStack.Api
{
	public class CandyService : Service
	{
		public object Get(Candy request)
		{
			if (request.Id != default(uint))
			{
				var candy = Db.GetById<Candy>(request.Id);

				return candy;
			}

			return new HttpResult(HttpStatusCode.BadRequest);
		}

		public object Get(CandyRequest request)
		{
			if (request.Ids != null && request.Ids.Any())
			{
				var candies = Db.GetByIds<Candy>(request.Ids);

				return candies;
			}

			if (request.MinPrice.HasValue || request.MaxPrice.HasValue)
			{
				return SearchByPrice(request.MinPrice, request.MaxPrice);
			}

			return Db.Select<Candy>();
		}

		public object Post(Candy request)
		{
			if (request.Id != default(uint))
			{
				return new HttpResult(HttpStatusCode.Conflict);
			}

			Db.Insert(request);

			var id = Db.GetLastInsertId();

			request.Id = Convert.ToUInt16(id);

			return request;
		}

		public object Put(Candy request)
		{
			if (request.Id == default(uint))
			{
				return new HttpResult(HttpStatusCode.BadRequest);
			}

			Db.Save(request);

			return request;
		}

		public object Delete(Candy request)
		{
			if (request.Id == default(uint))
			{
				return new HttpResult(HttpStatusCode.BadRequest);
			}

			Db.DeleteById<Candy>(request.Id);

			return new HttpResult(HttpStatusCode.OK);
		}

		private List<Candy> SearchByPrice(decimal? minPrice, decimal? maxPrice)
		{
			if (minPrice.HasValue && maxPrice.HasValue)
			{
				return Db.Select<Candy>(c => c.Price >= minPrice.Value && c.Price <= maxPrice.Value);
			}

			return minPrice.HasValue
				       ? Db.Select<Candy>(c => c.Price >= minPrice.Value)
				       : Db.Select<Candy>(c => c.Price <= maxPrice.Value);
		}
	}
}