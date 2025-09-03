using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.Services;
using GerenciamentoLivros.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoLivros.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;
    private readonly IAuthorService _authorService;
    private readonly IGenreService _genreService;

    public BookController(IBookService service, IAuthorService authorService, IGenreService genreService)
    {
        _service = service;
        _authorService = authorService;
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var author = await _authorService.GetByIdAsync(dto.IdAuthor);
        var genre = await _genreService.GetByIdAsync(dto.IdGenre);
        if (author == null) return BadRequest($"Author Id {dto.IdAuthor} não encontrado.");
        if (genre == null) return BadRequest($"Genre Id {dto.IdGenre} não encontrado.");
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "1.0" }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BookDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != dto.Id) return BadRequest("Registro não encontrado");
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();
        var author = await _authorService.GetByIdAsync(dto.IdAuthor);
        var genre = await _genreService.GetByIdAsync(dto.IdGenre);
        if (author == null) return BadRequest($"Author Id {dto.IdAuthor} não encontrado.");
        if (genre == null) return BadRequest($"Genre Id {dto.IdGenre} não encontrado.");
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
