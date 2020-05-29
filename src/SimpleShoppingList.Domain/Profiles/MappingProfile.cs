using System;
using AutoMapper;
using SimpleShoppingList.DataAccess.Entities;
using SimpleShoppingList.Domain.Models;

namespace SimpleShoppingList.Domain.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShoppingListEntity, ShoppingListModel>();
            CreateMap<ShoppingListModel, ShoppingListEntity>();
            CreateMap<ProductEntity, ProductModel>()
                .ForMember(dest=>dest.CreateDate, opt=>opt.MapFrom(src=>src.CreateDate.ToShortDateString()));
            CreateMap<ProductModel, ProductEntity>()
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Parse(src.CreateDate)));
        }
    }
}