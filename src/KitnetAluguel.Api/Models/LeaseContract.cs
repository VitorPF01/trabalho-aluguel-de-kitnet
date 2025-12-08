namespace KitnetAluguel.Api.Models;

public class LeaseContract
{
    public int Id { get; set; }
    public int KitnetId { get; set; }
    public Kitnet? Kitnet { get; set; }
    public int TenantId { get; set; }
    public Tenant? Tenant { get; set; }
    public decimal RentValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool IsActive => !EndDate.HasValue || EndDate.Value > DateTime.UtcNow.Date;
}
