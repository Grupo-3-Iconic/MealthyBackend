namespace Mealthy.Mealthy.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Category { get; set; }
    public int Price { get; set; }
    public string Unit { get; set; }
    public int Quantity { get; set; }
    public int photoUrl { get; set; }
}