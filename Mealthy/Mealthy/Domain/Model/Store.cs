namespace Mealthy.Mealthy.Domain.Model;

public class Store
{
    public int Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string photoUrl { get; set; }

    //Lista de IDs de los productos
    private IList<int> products { get; set; }

}