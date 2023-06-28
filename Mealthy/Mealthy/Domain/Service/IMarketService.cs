using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface IMarketService
{
    Task<IEnumerable<Market>> ListAsync();
    Task<MarketResponse> SaveAsync(Market market);
    Task<MarketResponse> UpdateAsync(int id, Market market);
    Task<MarketResponse> DeleteAsync(int id);
}