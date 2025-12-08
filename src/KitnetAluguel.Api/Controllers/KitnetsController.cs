using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KitnetAluguel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KitnetsController : ControllerBase
{
    private readonly IKitnetService _service;

    public KitnetsController(IKitnetService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetAllAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var kitnet = await _service.GetByIdAsync(id);
        if (kitnet is null)
            return NotFound();
        return Ok(kitnet);
    }

    [HttpPost]
    public async Task<IActionResult> Create(KitnetCreateRequest request)
    {
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, KitnetUpdateRequest request)
    {
        var updated = await _service.UpdateAsync(id, request);
        if (updated is null)
            return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok)
            return NotFound();
        return NoContent();
    }
}
