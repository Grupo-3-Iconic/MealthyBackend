namespace Mealthy.Mealthy.Domain.Model;

public class Menu
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //Relationships
    public IList<Recipe> Recipes { get; set; } = new List<Recipe>();
}