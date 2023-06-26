using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveMenuResource
{
    [Required(ErrorMessage = "El título es requerido.")]
    [MaxLength(30)]
    public string Title { get; set; }
    [Required(ErrorMessage = "La descripción es requerida.")]
    [MaxLength(100)]
    public string Description { get; set; }
}