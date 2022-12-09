using FluentValidation;
using WebApplication1.Controllers;

namespace WebApplication1.Validators
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty");
			RuleFor(x => x.Email).EmailAddress().NotEmpty();
			RuleFor(x => x.PricePerUnit).InclusiveBetween(1, 100).When(x => x.Quantity > 0).WithErrorCode("429");
		}
	}
}
