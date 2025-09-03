using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.ViewModels;

namespace GerenciamentoLivros.Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorViewModel>> GetAllAsync();
    Task<AuthorViewModel?> GetByIdAsync(int id);
    Task<AuthorViewModel> CreateAsync(AuthorDto dto);
    Task UpdateAsync(AuthorDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(AuthorViewModel existing);
}
