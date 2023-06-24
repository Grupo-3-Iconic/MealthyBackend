using Mealthy.Mealthy.Domain.Models;

namespace Mealthy.Mealthy.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>>ListAsync();
    Task AddAsync(Product product); 
    Task<Product> FindByIdAsync(int productId); 
    Task<Product> FindByNameAsync(string name);
    void Update(Product product); 
    void Remove(Product product);
}