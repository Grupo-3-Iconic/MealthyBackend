using System.ComponentModel.DataAnnotations.Schema;
using Mealthy.Mealthy.Domain.Models;

namespace Mealthy.Mealthy.Domain.Model;

public class Store
{
    public int Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string photoUrl { get; set; }

    //Lista de IDs de los productos
    public IList<int> ProductsId { get; set; }

    [NotMapped]
    public string ProductsIdString
    {
        get{return string.Join(",", ProductsId);}
        set { ProductsId = value.Split(',').Select(int.Parse).ToList(); }
    }


}