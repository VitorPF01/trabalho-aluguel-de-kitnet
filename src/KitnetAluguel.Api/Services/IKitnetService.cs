using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Models;

namespace KitnetAluguel.Api.Services;

public interface IKitnetService
{
    Task<Kitnet> CreateAsync(KitnetCreateRequest request);
    Task<IEnumerable<Kitnet>> GetAllAsync();
    Task<Kitnet?> GetByIdAsync(int id);
    Task<Kitnet?> UpdateAsync(int id, KitnetUpdateRequest request);
    Task<bool> DeleteAsync(int id);
}
