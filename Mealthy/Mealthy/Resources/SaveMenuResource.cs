using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveMenuResource
{
    [Required(ErrorMessage = "El día es requerido.")]
    [MaxLength(30)]
    public string Day { get; set; }
    [Required(ErrorMessage = "La comida es requerida.")]
    [MaxLength(30)]
    public string Meal { get; set; }
}