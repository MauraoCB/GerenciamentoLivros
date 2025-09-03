using AutoMapper;
using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.Entities;
using GerenciamentoLivros.Repositories;
using GerenciamentoLivros.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoLivros.Services;

public class BookService : IBookService
{
    private readonly IRepository<Book> _repository;
    private readonly IRepository<Author> _authorRepository;
    private readonly IRepository<Genre> _genreRepository;
    private readonly IMapper _mapper;

    public BookService(IRepository<Book> repository, IRepository<Author> authorRepository, IRepository<Genre> genreRepository, IMapper mapper)
    {
        _repository = repository;
        _authorRepository = authorRepository;
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookViewModel>> GetAllAsync()
    {
        var books = await _repository.GetAllAsync();
        var bookViewModels = new List<BookViewModel>();
        foreach (var book in books)
        {
            var vm = _mapper.Map<BookViewModel>(book);
            vm.AuthorName = book.Author?.Name ?? string.Empty;
            vm.GenreName = book.Genre?.Name ?? string.Empty;
            bookViewModels.Add(vm);
        }
        return bookViewModels;
    }

    public async Task<BookViewModel?> GetByIdAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book == null) return null;
        var vm = _mapper.Map<BookViewModel>(book);
        vm.AuthorName = book.Author?.Name ?? string.Empty;
        vm.GenreName = book.Genre?.Name ?? string.Empty;
        return vm;
    }

    public async Task<BookViewModel> CreateAsync(BookDto dto)
    {
        var entity = _mapper.Map<Book>(dto);
        entity.CreationDate = DateTime.UtcNow;
        entity.UpdateUser = UserContext.GetCurrentUser();
        var created = await _repository.AddAsync(entity);
        var vm = _mapper.Map<BookViewModel>(created);
        vm.AuthorName = created.Author?.Name ?? string.Empty;
        vm.GenreName = created.Genre?.Name ?? string.Empty;
        return vm;
    }

    public async Task UpdateAsync(BookDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity == null) throw new InvalidOperationException("Registro não encontrado");

        // Atualize apenas os campos necessários
        entity.Title = dto.Title;
        entity.Synopsis = dto.Synopsis;
        entity.ISBN = dto.ISBN;
        entity.Edition = dto.Edition;
        entity.PublicationYear = dto.PublicationYear;
        entity.IdAuthor = dto.IdAuthor;
        entity.IdGenre = dto.IdGenre;
        entity.UpdateDate = DateTime.UtcNow;
        entity.UpdateUser = UserContext.GetCurrentUser();

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
