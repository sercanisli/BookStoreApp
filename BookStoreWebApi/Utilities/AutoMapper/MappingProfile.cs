﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace BookStoreWebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book,BookDto>().ReverseMap();
            CreateMap<BookDtoForInsertion, Book>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDtoForInsertion, Category>().ReverseMap();
            CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
        }
    }
}
