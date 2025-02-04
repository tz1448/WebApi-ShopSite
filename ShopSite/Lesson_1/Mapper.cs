﻿using AutoMapper;
using DTO;
using Entities;

namespace Lesson1_login;
public class Mapper : Profile
{

	public Mapper()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
		CreateMap<Product, ProductDto>().ForMember(productDto => productDto.CategoryName,
														opt => opt.MapFrom(product => product.Category.Name)).ReverseMap();

		CreateMap<ProductDto, Product>();
        CreateMap<UserLoginDto, User>();
        CreateMap<User, UserDto>().ReverseMap();
		CreateMap<Order,OrderDto >().ReverseMap();
		CreateMap<OrderItem, OrderItemDto>().ReverseMap();
		


    }

}



