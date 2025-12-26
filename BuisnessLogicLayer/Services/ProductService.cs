using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Validations;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using FluentValidation;

namespace BuisnessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IValidator<ProdcutAddRequest> _productAddValidator;
        private readonly IValidator<ProductUpdateRequest> _productUpdateValidator;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            ValidatorFactory validatorfactory = new ValidatorFactory();
            _productAddValidator = validatorfactory.GetValidator<ProdcutAddRequest>();
            _productUpdateValidator = validatorfactory.GetValidator<ProductUpdateRequest>();
            _mapper = mapper;
        }

        public async Task<ProductResponse?> AddProduct(ProdcutAddRequest request)
        {
            var validationResult = await _productAddValidator.ValidateAsync(request);
            if (validationResult is not { IsValid: true })
            {
                //throw new Exception(validationResult.ToDictionary());
            }
            Product product = _mapper.Map<Product>(request);

            var added = await _repo.AddProduct(product);
            return added == null ? null : MapToResponse(added);
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            return await _repo.deleteProduct(productId);
        }

        public async Task<ProductResponse?> GetProductByExpression(Func<Product, bool> predicate)
        {
            var prod = await _repo.GetProductByExpression(predicate);
            return prod == null ? null : MapToResponse(prod);
        }

        public async Task<ProductResponse?> GetProductById(Guid productId)
        {
            var prod = await _repo.GetProductById(productId);
            return prod == null ? null : MapToResponse(prod);
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            var prods = await _repo.GetProducts();
            return prods.Select(MapToResponse);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsByExpression(Func<Product, bool> predicate)
        {
            var prods = await _repo.GetProductsByExpression(predicate);
            return prods.Select(MapToResponse);
        }

        public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest request)
        {
            //var validationResult = await _productUpdateValidator.ValidateAsync(request);
            //if (validationResult is not { IsValid: true })
            //{
            //    //throw new Exception(validationResult.ToDictionary());
            //}

            var existing = await _repo.GetProductById(request.ProductId);
            if (existing == null)
                return null;

            existing.ProductName = request.ProductName ?? existing.ProductName;
            existing.Category = request.Category.ToString() ?? existing.Category;
            existing.UnitPrice = request.UnitPrice ?? existing.UnitPrice;
            existing.QuantityInStock = request.QuantityInStock ?? existing.QuantityInStock;

            var updated = await _repo.UpdateProduct(existing);
            return updated == null ? null : MapToResponse(updated);
        }

        private ProductResponse MapToResponse(Product p)
        {
            return _mapper.Map<ProductResponse>(p);
        }
    }
}
