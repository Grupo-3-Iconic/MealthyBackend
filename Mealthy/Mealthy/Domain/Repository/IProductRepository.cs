using System.Collections;
using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>>ListAsync();
    Task AddAsync(Product product); 
    Task<IEnumerable<Product>> FindByStoreIdAsync(int productId);
    Task<Product> FindByIdAsync(int id);
    Task<Product> FindByNameAsync(string name);
    void Update(Product product); 
    void Remove(Product product);
}