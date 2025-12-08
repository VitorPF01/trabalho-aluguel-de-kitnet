namespace KitnetAluguel.Api.DTOs;

public record LeaseCreateRequest(int KitnetId, int TenantId, decimal RentValue, DateTime StartDate, DateTime? EndDate);
public record LeaseUpdateRequest(decimal RentValue, DateTime StartDate, DateTime? EndDate);
