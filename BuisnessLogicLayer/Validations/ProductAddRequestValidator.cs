using BuisnessLogicLayer.DTO;
using FluentValidation;

namespace BuisnessLogicLayer.Validations
{
    public class ProductAddRequestValidator:AbstractValidator<ProdcutAddRequest>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(x => x.Category)
                .IsInEnum().WithMessage("Category must not exceed 50 characters.");
            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price must be non-negative.")
                .When(x => x.UnitPrice.HasValue);
            RuleFor(x => x.QuantityInStock)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity in stock must be non-negative.")
                .When(x => x.QuantityInStock.HasValue);
        }
    }
}
