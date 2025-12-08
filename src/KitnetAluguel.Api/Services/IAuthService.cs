using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Models;

namespace KitnetAluguel.Api.Services;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterUserRequest request);
    Task<LoginResponse?> LoginAsync(LoginRequest request);
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}
