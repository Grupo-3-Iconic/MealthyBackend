using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface IStoreService
{
    Task<IEnumerable<Store>> ListAsync();
    Task<StoreResponse> SaveAsync(Store store);
    Task<StoreResponse> UpdateAsync(int id, Store store);
    Task<StoreResponse> DeleteAsync(int id);

}