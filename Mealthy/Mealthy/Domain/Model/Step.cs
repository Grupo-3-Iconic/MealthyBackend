namespace Mealthy.Mealthy.Domain.Model;

public class Step
{
    public int Id { get; set; }
    public string Description { get; set; }
    //Relationships
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}