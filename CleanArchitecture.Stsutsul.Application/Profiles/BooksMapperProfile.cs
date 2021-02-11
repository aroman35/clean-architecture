using AutoMapper;
using CleanArchitecture.Stsutsul.Application.Models;
using CleanArchitecture.Stsutsul.Domain;

namespace CleanArchitecture.Stsutsul.Application.Profiles
{
    public class BooksMapperProfile : Profile
    {
        public BooksMapperProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(x => x.Name, expression => expression.MapFrom(m => m.Name));
        }
    }
}