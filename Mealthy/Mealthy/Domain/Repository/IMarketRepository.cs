using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IMarketRepository
{
    Task<IEnumerable<Market>> ListAsync();
    Task AddAsync(Market market);
    Task<Market> FindByIdAsync(int id);
    void Update(Market market);
    void Remove(Market market);

}