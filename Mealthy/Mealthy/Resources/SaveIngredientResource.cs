using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveIngredientResource
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required]
    [MaxLength(10)]
    public string Unit { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int RecipeId { get; set; }
}