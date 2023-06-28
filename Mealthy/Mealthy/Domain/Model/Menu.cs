namespace Mealthy.Mealthy.Domain.Model;

public class Menu
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Meal { get; set; }
    //Relationships
    public int RecipeId { get; set; }
}