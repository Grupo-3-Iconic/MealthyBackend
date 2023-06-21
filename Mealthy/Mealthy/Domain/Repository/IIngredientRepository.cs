using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> ListAsync();
    Task AddAsync(Ingredient ingredient);
    Task<Ingredient> FindByIdAsync(int id);
    Task<Ingredient> FindByNameAsync(string name);
    Task<IEnumerable<Ingredient>> FindByRecipeIdAsync(int id);
    void Update(Ingredient ingredient);
    void Remove(Ingredient ingredient);
}