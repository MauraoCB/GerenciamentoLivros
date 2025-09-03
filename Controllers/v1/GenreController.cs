using GerenciamentoLivros.DTOs;
using GerenciamentoLivros.Services;
using GerenciamentoLivros.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoLivros.Controllers.v1;

/// <summary>
/// Controller para operações de gênero.
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
    /// Retorna todos os gêneros.
    /// </summary>
    /// <returns>Lista de gêneros.</returns>
    /// <response code="200">Retorna a lista de gêneros.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Retorna um gênero pelo Id.
    /// </summary>
    /// <param name="id">Id do gênero.</param>
    /// <returns>Gênero encontrado.</returns>
    /// <response code="200">Retorna o gênero.</response>
    /// <response code="404">Gênero não encontrado.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Cria um novo gênero.
    /// </summary>
    /// <param name="dto">Dados do gênero.</param>
    /// <returns>Gênero criado.</returns>
    /// <response code="201">Retorna o gênero criado.</response>
    /// <response code="400">Dados inválidos.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenreDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "1.0" }, created);
    }

    /// <summary>
    /// Atualiza um gênero existente.
    /// </summary>
    /// <param name="id">Id do gênero.</param>
    /// <param name="dto">Dados do gênero.</param>
    /// <response code="204">Gênero atualizado.</response>
    /// <response code="400">Dados inválidos ou Id diferente.</response>
    /// <response code="404">Gênero não encontrado.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] GenreDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != dto.Id) return BadRequest("Registro não encontrado");
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Remove um gênero pelo Id.
    /// </summary>
    /// <param name="id">Id do gênero.</param>
    /// <response code="204">Gênero removido.</response>
    /// <response code="404">Gênero não encontrado.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
