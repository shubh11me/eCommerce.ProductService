using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) {
            _db= db;
        }
        public async Task<Product?> AddProduct(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> deleteProduct(Guid productId)
        {
            Product? product= await GetProductById(productId);
            if (product is null)
            {
                return false;
            }
            _db.Products.Remove(product);
            int affectedRows=await _db.SaveChangesAsync();
            if (affectedRows > 1)
            {
                //Log warning: More than one row affected during delete operation
            }
            return affectedRows>0;
        }

        public async Task<Product?> GetProductByExpression(Func<Product, bool> predicate)
        {
            return _db.Products.FirstOrDefault(predicate);
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
           return await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return _db.Products.AsEnumerable();
        }

        public async Task<IEnumerable<Product>> GetProductsByExpression(Func<Product, bool> predicate)
        {
            return _db.Products.Where(predicate).AsEnumerable();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            int afftectedRows=await _db.SaveChangesAsync();
            if (afftectedRows > 1)
            {
                //Log warning: More than one row affected during update operation
            }
            return afftectedRows>0 ? product : null;
        }
    }
}
