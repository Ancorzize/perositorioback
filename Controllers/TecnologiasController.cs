using Microsoft.AspNetCore.Mvc;
using PortafolioApi.DTOs.Tecnologias;
using PortafolioApi.Services;

namespace PortafolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TecnologiasController : ControllerBase
{
    private readonly ITecnologiaService _service;

    public TecnologiasController(ITecnologiaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result is null) return NotFound(new { message = "Registro no encontrado" });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TecnologiaCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] TecnologiaUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound(new { message = "Registro no encontrado" });

        return Ok(new { message = "Registro actualizado correctamente" });
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound(new { message = "Registro no encontrado" });

        return Ok(new { message = "Registro eliminado correctamente" });
    }
}