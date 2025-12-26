using AutoMapper;
using BuisnessLogicLayer.DTO;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.Mappers
{
    public class ProductUpdateRequestToProductMappingProfile : Profile
    {
        public ProductUpdateRequestToProductMappingProfile()
        {
            CreateMap<ProductUpdateRequest, Product>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.ProductName))
                .ForMember(dest => dest.Category, src => src.MapFrom(s => s.Category))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(s => s.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, src => src.MapFrom(s => s.QuantityInStock));
        }
    }

    public class ProductToProductUpdateRequestMappingProfile : Profile
    {
        public ProductToProductUpdateRequestMappingProfile()
        {
            CreateMap<Product, ProductUpdateRequest>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.ProductName))
                .ForMember(dest => dest.Category, src => src.MapFrom(s => s.Category))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(s => s.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, src => src.MapFrom(s => s.QuantityInStock));
        }
    }
    public class ProductToProductResponse:Profile
    {
        public ProductToProductResponse()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.ProductName, src => src.MapFrom(s => s.ProductName))
                .ForMember(dest => dest.Category, src => src.MapFrom(s => s.Category))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(s => s.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, src => src.MapFrom(s => s.QuantityInStock));
        }
    }
}
