namespace KitnetAluguel.Api.DTOs;

public record PaymentCreateRequest(int LeaseContractId, decimal Amount, DateTime PaymentDate, int Month, int Year);
public record PaymentUpdateRequest(decimal Amount, DateTime PaymentDate, int Month, int Year);
