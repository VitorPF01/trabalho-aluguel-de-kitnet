namespace KitnetAluguel.Api.Models;

public class Kitnet
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Address { get; set; } = "";
    public decimal BaseRentValue { get; set; }
    public double Area { get; set; }
    public string Status { get; set; } = "Disponivel";
}
