using System.Linq;
using System.Net;
using CandyStack.DTO;
using CandyStack.Domain;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.OrmLite;

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

			return Db.Select<Candy>();
		}
	}
}