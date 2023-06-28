using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;


namespace Mealthy.Mealthy.Domain.Service;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int id, Product product);
    Task<ProductResponse> DeleteAsync(int id);
}