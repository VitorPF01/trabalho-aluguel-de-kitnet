using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitnetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KitnetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Kitnets.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var kit = await _context.Kitnets.FindAsync(id);
            return kit == null ? NotFound() : Ok(kit);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kitnet kitnet)
        {
            _context.Kitnets.Add(kitnet);
            await _context.SaveChangesAsync();
            return Ok(kitnet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Kitnet kitnet)
        {
            if (id != kitnet.Id)
                return BadRequest();

            _context.Entry(kitnet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(kitnet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kit = await _context.Kitnets.FindAsync(id);
            if (kit == null)
                return NotFound();

            _context.Kitnets.Remove(kit);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
