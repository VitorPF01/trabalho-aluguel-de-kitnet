using System.Security.Cryptography;
using System.Text;
using KitnetAluguel.Api.Data;
using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KitnetAluguel.Api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> RegisterAsync(RegisterUserRequest request)
    {
        var exists = await _context.Users.AnyAsync(u => u.Email == request.Email);
        if (exists)
            throw new InvalidOperationException("Email ja cadastrado");

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = HashPassword(request.Password)
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user is null)
            return null;

        if (!VerifyPassword(request.Password, user.PasswordHash))
            return null;

        var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        return new LoginResponse(token, user.Name, user.Email);
    }

    public string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        var hashOfInput = HashPassword(password);
        return hashOfInput == passwordHash;
    }
}
