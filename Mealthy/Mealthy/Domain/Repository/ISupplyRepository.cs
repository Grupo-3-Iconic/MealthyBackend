using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface ISupplyRepository
{
    Task<IEnumerable<Supply>> ListAsync();
    Task AddAsync(Supply supply);
    Task<Supply> FindByIdAsync(int id);
    Task<Supply> FindByNameAsync(string name);
    void Update(Supply supply);
    void Remove(Supply supply);
}