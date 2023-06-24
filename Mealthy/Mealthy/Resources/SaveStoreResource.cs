using System.ComponentModel.DataAnnotations.Schema;

namespace Mealthy.Mealthy.Resources;

public class SaveStoreResource
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public IList<int> ProductsId { get; set; }
    
    [NotMapped]
    public string ProductsIdString
    {
        get{return string.Join(",", ProductsId);}
        set { ProductsId = value.Split(',').Select(int.Parse).ToList(); }
    }
}