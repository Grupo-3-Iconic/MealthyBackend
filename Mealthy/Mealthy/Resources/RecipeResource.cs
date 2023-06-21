namespace Mealthy.Mealthy.Resources;
//Defines the shape of the data that’s going to be returned when a recipe is requested.
public class RecipeResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Servings { get; set; }
    public string PreparationTime { get; set; }
    public IList<IngredientResource> Ingredients { get; set; } = new List<IngredientResource>();
    public IList<StepResource> Steps { get; set; } = new List<StepResource>();
}