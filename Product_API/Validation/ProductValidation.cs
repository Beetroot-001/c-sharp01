using FluentValidation;
using Product_API.Data;

namespace Product_API.Validation
{
    public class ProductValidation: AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Taytle).NotEmpty().NotNull();
            RuleFor(x => x.Producer).NotEmpty().NotNull();
            RuleFor(x => x.Quantity).NotEmpty().LessThan(0);
            RuleFor(x => x.Priсe).NotEmpty().LessThan(0);
            RuleFor(x => x.Description).Length(0, 150);
        }
    }
}
