namespace KitnetAluguel.Api.Models;

public class Payment
{
    public int Id { get; set; }
    public int LeaseContractId { get; set; }
    public LeaseContract? LeaseContract { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}
