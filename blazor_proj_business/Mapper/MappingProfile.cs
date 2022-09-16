using System;
using AutoMapper;
using blazor_proj_dataAccess;
using blazor_proj_models;

namespace blazor_proj_business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

