using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.ViewModels;

namespace GerenciamentoLivros.Services;

public interface IGenreService
{
    Task<IEnumerable<GenreViewModel>> GetAllAsync();
    Task<GenreViewModel?> GetByIdAsync(int id);
    Task<GenreViewModel> CreateAsync(GenreDto dto);
    Task UpdateAsync(GenreDto dto);
    Task DeleteAsync(int id);
}
