using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IMenuRepository
{
    Task<IEnumerable<Menu>> ListAsync();
    Task AddAsync(Menu menu);
    Task<Menu> FindByIdAsync(int id);
    Task<Menu> FindByDayAsync(string day);
    void Update(Menu menu);
    void Remove(Menu menu);
}