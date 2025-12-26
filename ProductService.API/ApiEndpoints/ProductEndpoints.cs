using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Services;

namespace ProductService.API.ApiEndpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder Register(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/api/Product/", async (IProductService productService) => Results.Ok(await productService.GetProducts()));
            routeBuilder.MapGet("/api/Product/{id:guid}", async (IProductService productService,Guid id) => {
                var prod = await productService.GetProductById(id);
                return prod is null ? Results.NotFound() : Results.Ok(prod);
            });

            routeBuilder.MapPost("/api/Product", async (ProdcutAddRequest product, IProductService productService) =>
            {
                var prod = await productService.AddProduct(product);
                return Results.Created($"/api/Product/{prod.ProductId}", prod);
            })
            .WithName("AddProduct");

            routeBuilder.MapPut("/api/Product/Update", async (ProductUpdateRequest request, IProductService _productService) =>
            {
                var updated = await _productService.UpdateProduct(request);
                if (updated == null) return Results.NotFound();
                return Results.Ok(updated);
            }).WithName("UpdateProduct");
            return routeBuilder;
        }
    }
}
