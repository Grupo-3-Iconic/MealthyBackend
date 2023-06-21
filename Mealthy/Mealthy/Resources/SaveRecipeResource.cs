using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveRecipeResource
{
    [Required]
    [MaxLength(30)]
    public string Title { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required]
    [MaxLength(10)]
    public string PreparationTime { get; set; }
    [Required]
    public int Servings { get; set; }
}