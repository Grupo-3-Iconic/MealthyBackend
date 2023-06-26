using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> ListAsync();
    Task<IEnumerable<Ingredient>> ListByRecipeIdAsync(int recipeId);
    Task<IngredientResponse> SaveAsync(Ingredient ingredient);
    Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient);
    Task<IngredientResponse> DeleteAsync(int id);
}