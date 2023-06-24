using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int id, Product product);
    Task<ProductResponse> DeleteAsync(int id);
}