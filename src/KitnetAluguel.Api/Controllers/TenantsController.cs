using KitnetAluguel.Api.Data;
using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KitnetAluguel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TenantsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tenants = await _context.Tenants.AsNoTracking().ToListAsync();
        return Ok(tenants);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TenantCreateRequest request)
    {
        var entity = new Tenant
        {
            Name = request.Name,
            DocumentNumber = request.DocumentNumber,
            Phone = request.Phone,
            Email = request.Email
        };
        _context.Tenants.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, entity);
    }
}
