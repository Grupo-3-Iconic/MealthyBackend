using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Resources;

public class MenuResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IList<Recipe> Recipes { get; set; } = new List<Recipe>();
}