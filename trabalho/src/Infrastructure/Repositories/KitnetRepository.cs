
using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
    public class KitnetRepository
    {
        private readonly ApplicationDbContext _context;

        public KitnetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kitnet>> GetAll()
        {
            return await _context.Kitnets.ToListAsync();
        }

        public async Task<Kitnet> GetById(int id)
        {
            return await _context.Kitnets.FindAsync(id);
        }

        public async Task Create(Kitnet kitnet)
        {
            _context.Kitnets.Add(kitnet);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Kitnet kitnet)
        {
            _context.Kitnets.Update(kitnet);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var kitnet = await _context.Kitnets.FindAsync(id);
            if (kitnet != null)
            {
                _context.Kitnets.Remove(kitnet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
