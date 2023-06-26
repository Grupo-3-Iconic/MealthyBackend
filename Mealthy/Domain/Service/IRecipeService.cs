using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> ListAsync();
    Task<RecipeResponse> SaveAsync(Recipe recipe);
    Task<RecipeResponse> UpdateAsync(int id, Recipe recipe);
    Task<RecipeResponse> DeleteAsync(int id);
}