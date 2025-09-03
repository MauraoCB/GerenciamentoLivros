using AutoMapper;
using GerenciamentoLivros.Entities;
using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.ViewModels;

namespace GerenciamentoLivros.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Author
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorViewModel>().ReverseMap();

        // Genre
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<Genre, GenreViewModel>().ReverseMap();

        // Book
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name))
            .ReverseMap();
    }
}
