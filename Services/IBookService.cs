using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.ViewModels;

namespace GerenciamentoLivros.Services;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllAsync();
    Task<BookViewModel?> GetByIdAsync(int id);
    Task<BookViewModel> CreateAsync(BookDto dto);
    Task UpdateAsync(BookDto dto);
    Task DeleteAsync(int id);
}
