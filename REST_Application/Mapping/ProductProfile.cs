using AutoMapper;
using REST_Application.DTO;
using REST_Application.Models;

namespace REST_Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();

            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Product, ProductResponseDto>();
        }
    }
}
