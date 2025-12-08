using Microsoft.AspNetCore.Mvc;
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

        // GET api/kitnet
        [HttpGet]
        public IActionResult GetAll()
        {
            var kitnets = _context.Kitnets.ToList();
            return Ok(kitnets);
        }

        // GET api/kitnet/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var kitnet = _context.Kitnets.Find(id);
            if (kitnet == null)
            {
                return NotFound();
            }
            return Ok(kitnet);
        }

        // POST api/kitnet
        [HttpPost]
        public IActionResult Create(Kitnet kitnet)
        {
            _context.Kitnets.Add(kitnet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = kitnet.Id }, kitnet);
        }

        // PUT api/kitnet/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Kitnet kitnet)
        {
            if (id != kitnet.Id)
            {
                return BadRequest();
            }

            _context.Entry(kitnet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/kitnet/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var kitnet = _context.Kitnets.Find(id);
            if (kitnet == null)
            {
                return NotFound();
            }

            _context.Kitnets.Remove(kitnet);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
