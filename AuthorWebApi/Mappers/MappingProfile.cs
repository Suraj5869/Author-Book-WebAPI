using AuthorWebApi.DTOs;
using AuthorWebApi.Models;
using AutoMapper;

namespace AuthorWebApi.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ForMember(dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));
            CreateMap<AuthorDto, Author>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<Book, List<BookDto>>();
            CreateMap<Book, AuthorDto>()
                .ForMember(d => d.Id, v => v.MapFrom(s => s.AuthorId))
                .ForMember(d => d.Name, v => v.MapFrom(s => s.Author.Name))
                .ForMember(d => d.Email, v => v.MapFrom(s => s.Author.Email));
            CreateMap<AuthorDetailDto, AuthorDetail>();
            CreateMap<AuthorDetail, AuthorDetailDto>();
        }
    }
}
