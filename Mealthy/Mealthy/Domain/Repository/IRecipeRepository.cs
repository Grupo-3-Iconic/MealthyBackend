using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> ListAsync();
    Task AddAsync(Recipe recipe);
    Task<Recipe> FindByIdAsync(int id);
    void Update(Recipe recipe);
    void Remove(Recipe recipe);
}