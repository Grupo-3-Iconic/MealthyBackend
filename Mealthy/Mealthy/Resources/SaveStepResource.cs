using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveStepResource
{
    [Required(ErrorMessage = "La descripcion del paso a realizar es requerida.")]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required(ErrorMessage = "El id de la receta es requerido.")]
    public int RecipeId { get; set; }
}