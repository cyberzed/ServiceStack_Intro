﻿using System;
using CandyStack.Models.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Server.Data
{
	public class BagOfCandyPersister
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		public BagOfCandyPersister(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public void Create(BagOfCandy bagOfCandy)
		{
			using (var dbConnnection = dbConnectionFactory.Open())
			{
				dbConnnection.InsertOnly(bagOfCandy, ev => ev.Insert(bg => new {bg.Name, bg.Price}));

				var bagId = dbConnnection.GetLastInsertId();
				bagOfCandy.Id = Convert.ToUInt32(bagId);

				foreach (var detail in bagOfCandy.Details)
				{
					dbConnnection.Insert(detail);

					var detailId = dbConnnection.GetLastInsertId();
					detail.Id = Convert.ToUInt32(detailId);
				}
			}
		}
	}
}