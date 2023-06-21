using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveStepResource
{
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public int RecipeId { get; set; }
}