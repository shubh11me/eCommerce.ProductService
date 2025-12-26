using BuisnessLogicLayer.DTO;
using FluentValidation;

namespace BuisnessLogicLayer.Validations
{
    public class ProductUpdateRequestValidator:AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
        {
            RuleFor(x=>x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(500).WithMessage("Product name must not exceed 500 characters.");
            RuleFor(x => x.Category).IsInEnum().WithMessage("Invalid category.");
        }
    }
}
