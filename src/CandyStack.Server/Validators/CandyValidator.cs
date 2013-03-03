using CandyStack.Models.Domain;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceInterface;

namespace CandyStack.Server.Validators
{
	public class CandyValidator : AbstractValidator<Candy>
	{
		public CandyValidator()
		{
			RuleSet(ApplyTo.Delete | ApplyTo.Put, () => { RuleFor(c => c.Id).GreaterThan((ushort) 0); });
		}
	}
}