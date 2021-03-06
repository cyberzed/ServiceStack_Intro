﻿using System.Net;
using CandyStack.Models.Domain;
using CandyStack.Server.Data;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace CandyStack.Server.Api
{
	public class BagOfCandyService : Service
	{
		private readonly BagOfCandyPersister bagOfCandyPersister;

		public BagOfCandyService(BagOfCandyPersister bagOfCandyPersister)
		{
			this.bagOfCandyPersister = bagOfCandyPersister;
		}

		public object Get(BagOfCandy request)
		{
			if (request.Id != default(uint))
			{
				var bag = Db.GetById<BagOfCandy>(request.Id);

				return bag;
			}

			return Db.Select<BagOfCandy>();
		}

		public object Post(BagOfCandy request)
		{
			if (request.Id != default(uint))
				return new HttpResult(HttpStatusCode.BadRequest);

			bagOfCandyPersister.Create(request);

			return request;
		}
	}
}