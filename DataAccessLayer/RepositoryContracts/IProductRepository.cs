using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts
{
    public interface IProductRepository
    {
        /// <summary>
        /// Asynchronously retrieves a collection of available products.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see
        /// cref="Product"/> objects representing the available products. The collection is empty if no products are
        /// found.</returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// Asynchronously retrieves a collection of products that satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">A function that defines the conditions each product must meet to be included in the result. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of
        /// products that match the specified predicate. The collection is empty if no products match.</returns>
        Task<IEnumerable<Product>> GetProductsByExpression(Func<Product, bool> predicate);

        /// <summary>
        /// Asynchronously retrieves the product with the specified unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Product"/> if
        /// found; otherwise, <see langword="null"/>.</returns>
        Task<Product?> GetProductById(Guid productId);

        /// <summary>
        /// Asynchronously retrieves the first product that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">A function that defines the conditions of the product to search for. The function should return <see
        /// langword="true"/> for products that match the criteria.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first <see cref="Product"/>
        /// that matches the predicate, or <see langword="null"/> if no matching product is found.</returns>
        Task<Product?> GetProductByExpression(Func<Product, bool> predicate);

        /// <summary>
        /// Adds a new product to the data store asynchronously.
        /// </summary>
        /// <param name="product">The product to add. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added product, or null if
        /// the operation fails.</returns>
        Task<Product?> AddProduct(Product product);

        /// <summary>
        /// Updates the specified product in the data store asynchronously.
        /// </summary>
        /// <param name="product">The product to update. The product's identifier must correspond to an existing product in the data store.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated product if the
        /// update is successful; otherwise, null if the product does not exist.</returns>
        Task<Product?> UpdateProduct(Product product);
        /// <summary>
        /// Deletes the product with the specified unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if the product was
        /// successfully deleted; otherwise, <see langword="false"/>.</returns>
        Task<bool> deleteProduct(Guid productId);
    }
}
