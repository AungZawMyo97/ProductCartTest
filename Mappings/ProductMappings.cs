using AutoMapper;
using ProductCartTest.Dto;
using ProductCartTest.Models.EntityModels;

namespace ProductCartTest.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
