using AutoMapper;
using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.Models.DTOs;

namespace DotnetUOWDemo.Api.Profiles;

public class MyProfile : Profile
{
    public MyProfile()
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryDisplayDto>().ReverseMap();

        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Product, ProductDisplayDto>().ReverseMap();
    }
}
