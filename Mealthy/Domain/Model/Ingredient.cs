namespace Mealthy.Mealthy.Domain.Model;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public int Quantity { get; set; }
    //Relationships
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}