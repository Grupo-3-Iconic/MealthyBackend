using Mealthy.Mealthy.Domain.Model;

namespace Mealthy.Mealthy.Domain.Repository;

public interface IStepRepository
{
    Task<IEnumerable<Step>> ListAsync();
    Task AddAsync(Step step);
    Task<Step> FindByIdAsync(int id);
    Task<Step> FindByDescriptionAsync(string description);
    Task<IEnumerable<Step>> FindByRecipeIdAsync(int recipeId);
    void Update(Step step);
    void Remove(Step step);
}