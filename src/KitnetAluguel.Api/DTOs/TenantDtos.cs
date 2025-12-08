namespace KitnetAluguel.Api.DTOs;

public record TenantCreateRequest(string Name, string DocumentNumber, string Phone, string Email);
public record TenantUpdateRequest(string Name, string DocumentNumber, string Phone, string Email);
