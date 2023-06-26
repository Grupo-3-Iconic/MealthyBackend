using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface IMenuService
{
    Task<IEnumerable<Menu>> ListAsync();
    Task<MenuResponse> SaveAsync(Menu menu);
    Task<MenuResponse> UpdateAsync(int id, Menu menu);
    Task<MenuResponse> DeleteAsync(int id);
}