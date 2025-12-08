using KitnetAluguel.Api.Data;
using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KitnetAluguel.Api.Services;

public class KitnetService : IKitnetService
{
    private readonly AppDbContext _context;

    public KitnetService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Kitnet> CreateAsync(KitnetCreateRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Code))
            throw new ArgumentException("Codigo obrigatorio");

        if (request.BaseRentValue <= 0)
            throw new ArgumentException("Valor deve ser maior que zero");

        var entity = new Kitnet
        {
            Code = request.Code,
            Address = request.Address,
            BaseRentValue = request.BaseRentValue,
            Area = request.Area,
            Status = "Disponivel"
        };

        _context.Kitnets.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Kitnet>> GetAllAsync()
    {
        return await _context.Kitnets.AsNoTracking().ToListAsync();
    }

    public async Task<Kitnet?> GetByIdAsync(int id)
    {
        return await _context.Kitnets.AsNoTracking().FirstOrDefaultAsync(k => k.Id == id);
    }

    public async Task<Kitnet?> UpdateAsync(int id, KitnetUpdateRequest request)
    {
        var entity = await _context.Kitnets.FirstOrDefaultAsync(k => k.Id == id);
        if (entity is null)
            return null;

        entity.Code = request.Code;
        entity.Address = request.Address;
        entity.BaseRentValue = request.BaseRentValue;
        entity.Area = request.Area;
        entity.Status = request.Status;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Kitnets.FirstOrDefaultAsync(k => k.Id == id);
        if (entity is null)
            return false;

        var hasContract = await _context.LeaseContracts.AnyAsync(c => c.KitnetId == id && c.IsActive);
        if (hasContract)
            throw new InvalidOperationException("Nao e possivel excluir kitnet com contrato ativo");

        _context.Kitnets.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
