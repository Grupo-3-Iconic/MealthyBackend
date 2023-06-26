using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeRepository _recipeRepository;

    public IngredientService(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork, IRecipeRepository recipeRepository)
    {
        _ingredientRepository = ingredientRepository;
        _unitOfWork = unitOfWork;
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<Ingredient>> ListAsync()
    {
        return await _ingredientRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Ingredient>> ListByRecipeIdAsync(int recipeId)
    {
        return await _ingredientRepository.FindByRecipeIdAsync(recipeId);
    }
    public async Task<IngredientResponse> SaveAsync(Ingredient ingredient)
    {
        //Validate Recipe Id
        var existingRecipe = await _recipeRepository.FindByIdAsync(ingredient.RecipeId);
        if (existingRecipe == null)
            return new IngredientResponse("Invalid Recipe.");
        //Validate Ingredient Name
        var existingIngredient = await _ingredientRepository.FindByNameAsync(ingredient.Name);
        if (existingIngredient != null)
            return new IngredientResponse("Ingredient already exists.");
        try
        {
            //Add Ingredient
            await _ingredientRepository.AddAsync(ingredient);
            //Complete Transaction
            await _unitOfWork.CompleteAsync();
            //Return Ingredient
            return new IngredientResponse(ingredient);
        }
        catch (Exception e)
        {
            //Error Handling
            return new IngredientResponse($"An error occurred when saving the ingredient: {e.Message}");
        }
    }

    public async Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient)
    {
        var existingIngredient = await _ingredientRepository.FindByIdAsync(id);
        //Validate Ingredient
        if (existingIngredient == null)
            return new IngredientResponse("Ingredient not found.");
        //Validate Recipe Id
        var existingRecipe = await _recipeRepository.FindByIdAsync(ingredient.RecipeId);
        if (existingRecipe == null)
            return new IngredientResponse("Invalid Recipe.");
        //Validate Ingredient Name
        var existingIngredientName = await _ingredientRepository.FindByNameAsync(ingredient.Name);
        if (existingIngredientName != null && existingIngredientName.Id != id)
            return new IngredientResponse("Ingredient already exists.");
        //Update Ingredient
        existingIngredient.Name = ingredient.Name;
        existingIngredient.Quantity = ingredient.Quantity;
        existingIngredient.Unit = ingredient.Unit;
        try 
        {
            //Update Ingredient
            _ingredientRepository.Update(existingIngredient);
            //Complete Transaction
            await _unitOfWork.CompleteAsync();
            //Return Ingredient
            return new IngredientResponse(existingIngredient);
        }
        catch (Exception e)
        {
            //Error Handling
            return new IngredientResponse($"An error occurred when updating the ingredient: {e.Message}");
        }
    }

    public async Task<IngredientResponse> DeleteAsync(int ingredientId)
    {
        var existingIngredient = await _ingredientRepository.FindByIdAsync(ingredientId);
        //Validate Ingredient
        if (existingIngredient == null)
            return new IngredientResponse("Ingredient not found.");

        try
        {
            //Delete Ingredient
            _ingredientRepository.Remove(existingIngredient);
            //Complete Transaction
            await _unitOfWork.CompleteAsync();
            //Return Ingredient
            return new IngredientResponse(existingIngredient);
        }
        catch (Exception e)
        {
            //Error Handling
            return new IngredientResponse($"An error occurred when deleting the ingredient: {e.Message}");
        }
    }
}