using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IStoreRepository
{
    Task<Store> FindByName(string name);
    Task AddStoreAsync(Store store);
    Task<Store> FindBy()
}