using AutoMapper;
using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.Entities;
using GerenciamentoLivros.Repositories;
using GerenciamentoLivros.ViewModels;

namespace GerenciamentoLivros.Services;

/// <summary>
/// Serviço para operações relacionadas a autores.
/// </summary>
public class AuthorService : IAuthorService
{
    private readonly IRepository<Author> _repository;
    private readonly IMapper _mapper;

    public AuthorService(IRepository<Author> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorViewModel>> GetAllAsync()
    {
        var authors = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<AuthorViewModel>>(authors);
    }

    public async Task<AuthorViewModel?> GetByIdAsync(int id)
    {
        var author = await _repository.GetByIdAsync(id);
        return author == null ? null : _mapper.Map<AuthorViewModel>(author);
    }

    public async Task<AuthorViewModel> CreateAsync(AuthorDto dto)
    {
        var entity = _mapper.Map<Author>(dto);
        entity.CreationDate = DateTime.UtcNow;
        entity.UpdateUser = UserContext.GetCurrentUser();
        var created = await _repository.AddAsync(entity);
        return _mapper.Map<AuthorViewModel>(created);
    }

    public async Task UpdateAsync(AuthorDto dto)
    {
        var existingAuthor = await _repository.GetByIdAsync(dto.Id);
        if (existingAuthor == null)
            throw new KeyNotFoundException($"Author ID {dto.Id} não encontrado");

        _mapper.Map(dto, existingAuthor);
        existingAuthor.UpdateDate = DateTime.UtcNow;
        existingAuthor.UpdateUser = UserContext.GetCurrentUser();
        await _repository.UpdateAsync(existingAuthor);
    }

    /// <summary>
    /// Atualiza um autor existente a partir de um AuthorViewModel.
    /// </summary>
    /// <param name="existing">ViewModel do autor existente.</param>
    public async Task UpdateAsync(AuthorViewModel existing)
    {
        var existingAuthor = await _repository.GetByIdAsync(existing.Id);
        if (existingAuthor == null)
            throw new KeyNotFoundException($"Author ID {existing.Id} não encontrado");

        _mapper.Map(existing, existingAuthor);
        existingAuthor.UpdateDate = DateTime.UtcNow;
        existingAuthor.UpdateUser = UserContext.GetCurrentUser();
        await _repository.UpdateAsync(existingAuthor);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
