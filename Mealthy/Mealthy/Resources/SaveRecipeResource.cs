using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveRecipeResource
{
    [Required(ErrorMessage = "El título es requerido.")]
    [MaxLength(30)]
    public string Title { get; set; }
    [Required(ErrorMessage = "La descripción es requerida.")]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required(ErrorMessage = "El tiempo de preparación es requerido.")]
    [MaxLength(10)]
    public string PreparationTime { get; set; }
    [Required(ErrorMessage = "El número de porciones es requerido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de porciones debe ser mayor a cero.")]
    public int Servings { get; set; }
}