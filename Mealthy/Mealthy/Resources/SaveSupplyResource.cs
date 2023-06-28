using System.ComponentModel.DataAnnotations;

namespace Mealthy.Mealthy.Resources;

public class SaveSupplyResource
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required(ErrorMessage = "La unidad es requerida.")]
    [MaxLength(10)]
    public string Unit { get; set; }
    [Required(ErrorMessage = "La cantidad es requerida.")]
    public int Quantity { get; set; }
}