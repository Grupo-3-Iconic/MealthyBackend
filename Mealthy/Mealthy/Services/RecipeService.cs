using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Recipe>> ListAsync()
    {
        return await _recipeRepository.ListAsync();
    }

    public async Task<RecipeResponse> SaveAsync(Recipe recipe)
    {
        try {
            await _recipeRepository.AddAsync(recipe);
            await _unitOfWork.CompleteAsync();
            return new RecipeResponse(recipe);
        }
        catch (Exception ex) {
            return new RecipeResponse($"An error occurred while saving the Recipe: {ex.Message}");
        }
    }
    
    public async Task<RecipeResponse> UpdateAsync(int id, Recipe recipe)
    {
        var existingRecipe = await _recipeRepository.FindByIdAsync(id);
        
        if (existingRecipe == null)
            return new RecipeResponse("Recipe not found.");
        
        existingRecipe.Title = recipe.Title;
        existingRecipe.Description = recipe.Description;
        
        try {
            _recipeRepository.Update(existingRecipe);
            await _unitOfWork.CompleteAsync();
            return new RecipeResponse(existingRecipe);
        }
        catch (Exception ex) {
            return new RecipeResponse($"An error occurred while updating the Recipe: {ex.Message}");
        }
    }
    public async Task<RecipeResponse> DeleteAsync(int id)
    {
        var existingRecipe = await _recipeRepository.FindByIdAsync(id);
        
        if (existingRecipe == null)
            return new RecipeResponse("Recipe not found.");
        
        try {
            _recipeRepository.Remove(existingRecipe);
            await _unitOfWork.CompleteAsync();
            return new RecipeResponse(existingRecipe);
        }
        catch (Exception ex) {
            return new RecipeResponse($"An error occurred while deleting the Recipe: {ex.Message}");
        }
    }
}