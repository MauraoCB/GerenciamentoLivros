using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.Services;
using GerenciamentoLivros.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoLivros.Controllers.v1;

/// <summary>
/// Controller para opera��es de g�nero.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todos os g�neros.
    /// </summary>
    /// <returns>Lista de g�neros.</returns>
    /// <response code="200">Retorna a lista de g�neros.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Retorna um g�nero pelo Id.
    /// </summary>
    /// <param name="id">Id do g�nero.</param>
    /// <returns>G�nero encontrado.</returns>
    /// <response code="200">Retorna o g�nero.</response>
    /// <response code="404">G�nero n�o encontrado.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Cria um novo g�nero.
    /// </summary>
    /// <param name="dto">Dados do g�nero.</param>
    /// <returns>G�nero criado.</returns>
    /// <response code="201">Retorna o g�nero criado.</response>
    /// <response code="400">Dados inv�lidos.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenreDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "1.0" }, created);
    }

    /// <summary>
    /// Atualiza um g�nero existente.
    /// </summary>
    /// <param name="id">Id do g�nero.</param>
    /// <param name="dto">Dados do g�nero.</param>
    /// <response code="204">G�nero atualizado.</response>
    /// <response code="400">Dados inv�lidos ou Id diferente.</response>
    /// <response code="404">G�nero n�o encontrado.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] GenreDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != dto.Id) return BadRequest("Registro n�o encontrado");
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Remove um g�nero pelo Id.
    /// </summary>
    /// <param name="id">Id do g�nero.</param>
    /// <response code="204">G�nero removido.</response>
    /// <response code="404">G�nero n�o encontrado.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
