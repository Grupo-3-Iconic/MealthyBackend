namespace Mealthy.Mealthy.Resources;

public class StoreResource
{
    public int Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string photoUrl { get; set; }
    public List<int> productsId { get; set; }
}