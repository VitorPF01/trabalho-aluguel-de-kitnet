namespace KitnetAluguel.Api.DTOs;

public record KitnetCreateRequest(string Code, string Address, decimal BaseRentValue, double Area);
public record KitnetUpdateRequest(string Code, string Address, decimal BaseRentValue, double Area, string Status);
