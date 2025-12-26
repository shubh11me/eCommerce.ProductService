namespace BuisnessLogicLayer.DTO
{
    public record ProdcutAddRequest(
        string ProductName,
        CategoryOptions? Category,
        decimal? UnitPrice,
        int? QuantityInStock
    )
    {
        public ProdcutAddRequest()
            : this(default,default,default,default)
        {
        }
    }
}
