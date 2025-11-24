
using Api.Domain.Models;

namespace Api.Application.Services
{
    public interface IKitnetService
    {
        Task<IEnumerable<Kitnet>> GetAllKitnets();
        Task<Kitnet> GetKitnetById(int id);
        Task<Kitnet> CreateKitnet(Kitnet kitnet);
        Task<Kitnet> UpdateKitnet(int id, Kitnet kitnet);
        Task<bool> DeleteKitnet(int id);
    }

    public class KitnetService : IKitnetService
    {
        private readonly ApplicationDbContext _context;

        public KitnetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kitnet>> GetAllKitnets()
        {
            return await _context.Kitnets.ToListAsync();
        }

        public async Task<Kitnet> GetKitnetById(int id)
        {
            return await _context.Kitnets.FindAsync(id);
        }

        public async Task<Kitnet> CreateKitnet(Kitnet kitnet)
        {
            _context.Kitnets.Add(kitnet);
            await _context.SaveChangesAsync();
            return kitnet;
        }

        public async Task<Kitnet> UpdateKitnet(int id, Kitnet kitnet)
        {
            if (id != kitnet.Id)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(kitnet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return kitnet;
        }

        public async Task<bool> DeleteKitnet(int id)
        {
            var kitnet = await _context.Kitnets.FindAsync(id);
            if (kitnet == null)
            {
                return false;
            }

            _context.Kitnets.Remove(kitnet);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
