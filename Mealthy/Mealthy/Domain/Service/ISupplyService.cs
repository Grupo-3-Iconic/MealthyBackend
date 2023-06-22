using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface ISupplyService
{
    Task<IEnumerable<Supply>> ListAsync();
    Task<SupplyResponse> SaveAsync(Supply supply);
    Task<SupplyResponse> UpdateAsync(int id, Supply supply);
    Task<SupplyResponse> DeleteAsync(int id);
}