using BuisnessLogicLayer.DTO;
using FluentValidation;

namespace BuisnessLogicLayer.Validations
{
    public class ValidatorFactory
    {
        public IValidator<T> GetValidator<T>()
        {
            if (typeof(T) == typeof(ProdcutAddRequest))
            {
                return (IValidator<T>)new ProductAddRequestValidator();
            }
            else if (typeof(T) == typeof(ProductUpdateRequest))
            {
                return (IValidator<T>)new ProductUpdateRequestValidator();
            }
            throw new NotSupportedException($"No validator found for type {typeof(T).Name}");
        }
    }
}
