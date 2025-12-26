using AutoMapper;
using BuisnessLogicLayer.DTO;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.Mappers
{
    public class ProductAddRequestToProductMappingProfile:Profile
    {
        public ProductAddRequestToProductMappingProfile()
        {
            CreateMap<ProdcutAddRequest, Product>().ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.ProductName))
                .ForMember(dest => dest.Category, src => src.MapFrom(s => s.Category.ToString()))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(s => s.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, src => src.MapFrom(s => s.QuantityInStock));
        }
    }
    public class ProductToProductAddRequestMappingProfile : Profile
    {
        public ProductToProductAddRequestMappingProfile()
        {
            CreateMap<Product, ProdcutAddRequest>().ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.ProductName))
                .ForMember(dest => dest.Category, src => src.MapFrom(s => s.Category))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(s => s.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, src => src.MapFrom(s => s.QuantityInStock));
        }
    }
}
