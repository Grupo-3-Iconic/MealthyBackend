using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> ListAsync();
    Task AddAsync(Store store);
    Task<Store> FindByIdAsync(int id);
    void Update(Store store);
    void Remove(Store store);
}