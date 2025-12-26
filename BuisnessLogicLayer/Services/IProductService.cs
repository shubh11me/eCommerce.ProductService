using DataAccessLayer.Entities;
using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Services
{
    /// <summary>
    /// Service contract that provides operations for managing products.
    /// This interface exposes methods to query, add, update and delete products using DTOs.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable of
        /// <see cref="ProductResponse"/>. The enumerable is empty when no products are available.
        /// </returns>
        Task<IEnumerable<ProductResponse>> GetProducts();

        /// <summary>
        /// Asynchronously retrieves products that match the specified predicate.
        /// </summary>
        /// <param name="predicate">A function used to filter products. The predicate is evaluated against the
        /// data store's product entities.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable of
        /// <see cref="ProductResponse"/> that match the predicate. The enumerable is empty when no products match.
        /// </returns>
        Task<IEnumerable<ProductResponse>> GetProductsByExpression(Func<Product, bool> predicate);

        /// <summary>
        /// Asynchronously retrieves a single product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the
        /// <see cref="ProductResponse"/> if found; otherwise <c>null</c>.
        /// </returns>
        Task<ProductResponse?> GetProductById(Guid productId);

        /// <summary>
        /// Asynchronously retrieves the first product that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">A function used to identify the matching product.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the first matching
        /// <see cref="ProductResponse"/>, or <c>null</c> if no match is found.
        /// </returns>
        Task<ProductResponse?> GetProductByExpression(Func<Product, bool> predicate);

        /// <summary>
        /// Asynchronously adds a new product using the provided request DTO.
        /// </summary>
        /// <param name="request">The request containing product details to create.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the created
        /// <see cref="ProductResponse"/>, or <c>null</c> if the operation failed.
        /// </returns>
        Task<ProductResponse?> AddProduct(ProdcutAddRequest request);

        /// <summary>
        /// Asynchronously updates an existing product using the provided update request DTO.
        /// </summary>
        /// <param name="request">The update request containing the product identifier and updated values.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the updated
        /// <see cref="ProductResponse"/>, or <c>null</c> if the product does not exist or the update failed.
        /// </returns>
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest request);

        /// <summary>
        /// Asynchronously deletes a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result is <c>true</c> if the product was
        /// successfully deleted; otherwise <c>false</c>.
        /// </returns>
        Task<bool> DeleteProduct(Guid productId);
    }
}
