using AutoMapper;
using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.Entities;
using GerenciamentoLivros.Repositories;
using GerenciamentoLivros.ViewModels;

namespace GerenciamentoLivros.Services;

public class GenreService : IGenreService
{
    private readonly IRepository<Genre> _repository;
    private readonly IMapper _mapper;

    public GenreService(IRepository<Genre> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreViewModel>> GetAllAsync()
    {
        var genres = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<GenreViewModel>>(genres);
    }

    public async Task<GenreViewModel?> GetByIdAsync(int id)
    {
        var genre = await _repository.GetByIdAsync(id);
        return genre == null ? null : _mapper.Map<GenreViewModel>(genre);
    }

    public async Task<GenreViewModel> CreateAsync(GenreDto dto)
    {
        var entity = _mapper.Map<Genre>(dto);
        entity.CreationDate = DateTime.UtcNow;
        entity.UpdateUser = UserContext.GetCurrentUser();
        var created = await _repository.AddAsync(entity);
        return _mapper.Map<GenreViewModel>(created);
    }

    public async Task UpdateAsync(GenreDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity == null) throw new InvalidOperationException("Registro não encontrado");

        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.UpdateDate = DateTime.UtcNow;
        entity.UpdateUser = UserContext.GetCurrentUser();

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
