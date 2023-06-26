using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> ListAsync();
    Task AddAsync(Recipe recipe);
    Task<Recipe> FindByIdAsync(int id);
    Task<Recipe> FindByTitleAsync(string title);
    void Update(Recipe recipe);
    void Remove(Recipe recipe);
}