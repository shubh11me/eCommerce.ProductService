using Microsoft.AspNetCore.Mvc;
using BuisnessLogicLayer.Services;
using BuisnessLogicLayer.DTO;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok("Product Service is healthy.");
        }

             /// <summary>
        /// Search products by optional filters
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string? name, [FromQuery] string? category, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] int? minQty, [FromQuery] int? maxQty)
        {
            bool Predicate(DataAccessLayer.Entities.Product p)
            {
                if (!string.IsNullOrWhiteSpace(name) && (p.ProductName == null || !p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase)))
                    return false;
                if (!string.IsNullOrWhiteSpace(category) && (p.Category == null || !p.Category.Contains(category, StringComparison.OrdinalIgnoreCase)))
                    return false;
                if (minPrice.HasValue && (!p.UnitPrice.HasValue || p.UnitPrice.Value < minPrice.Value))
                    return false;
                if (maxPrice.HasValue && (!p.UnitPrice.HasValue || p.UnitPrice.Value > maxPrice.Value))
                    return false;
                if (minQty.HasValue && (!p.QuantityInStock.HasValue || p.QuantityInStock.Value < minQty.Value))
                    return false;
                if (maxQty.HasValue && (!p.QuantityInStock.HasValue || p.QuantityInStock.Value > maxQty.Value))
                    return false;
                return true;
            }

            var products = await _productService.GetProductsByExpression(Predicate);
            return Ok(products);
        }

        /// <summary>
        /// Get first product that matches filters
        /// </summary>
        [HttpGet("first")]
        public async Task<IActionResult> GetFirstProduct([FromQuery] string? name, [FromQuery] string? category)
        {
            bool Predicate(DataAccessLayer.Entities.Product p)
            {
                if (!string.IsNullOrWhiteSpace(name) && (p.ProductName == null || !p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase)))
                    return false;
                if (!string.IsNullOrWhiteSpace(category) && (p.Category == null || !p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)))
                    return false;
                return true;
            }

            var product = await _productService.GetProductByExpression(Predicate);
            if (product == null) return NotFound();
            return Ok(product);
        }


        /// <summary>
        /// Delete a product by id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deleted = await _productService.DeleteProduct(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
