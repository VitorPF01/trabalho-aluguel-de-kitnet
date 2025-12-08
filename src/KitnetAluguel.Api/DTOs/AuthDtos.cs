namespace KitnetAluguel.Api.DTOs;

public record RegisterUserRequest(string Name, string Email, string Password);
public record LoginRequest(string Email, string Password);
public record LoginResponse(string Token, string Name, string Email);
