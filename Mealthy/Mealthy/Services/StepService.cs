using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class StepService : IStepService
{
    private readonly IStepRepository _stepRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeRepository _recipeRepository;

    public StepService(IStepRepository stepRepository, IUnitOfWork unitOfWork, IRecipeRepository recipeRepository)
    {
        _stepRepository = stepRepository;
        _unitOfWork = unitOfWork;
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<Step>> ListAsync()
    {
        return await _stepRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Step>> ListByRecipeIdAsync(int recipeId)
    {
        return await _stepRepository.FindByRecipeIdAsync(recipeId);
    }
    
    public async Task<StepResponse> SaveAsync(Step step)
    {
        //Validate Recipe Id
        var existingRecipe = await _recipeRepository.FindByIdAsync(step.RecipeId);
        if (existingRecipe == null)
            return new StepResponse("Invalid Recipe.");
        //Validate Step Description
        var existingStep = await _stepRepository.FindByDescriptionAsync(step.Description);
        if (existingStep != null)
            return new StepResponse("Step already exists.");
        try 
        {
            //Add Step
            await _stepRepository.AddAsync(step);
            //Complete transaction
            await _unitOfWork.CompleteAsync();
            //Return Step
            return new StepResponse(step);
        }
        catch (Exception ex)
        {
            //Error Handling
            return new StepResponse($"An error occurred when saving the step: {ex.Message}");
        }
        
    }

    public async Task<StepResponse> UpdateAsync(int id, Step step)
    {
        var existingStep = await _stepRepository.FindByIdAsync(id);
        //Validate Step
        if (existingStep == null)
            return new StepResponse("Step not found.");
        //Validate Recipe Id
        var existingRecipe = await _recipeRepository.FindByIdAsync(step.RecipeId);
        if (existingRecipe == null)
            return new StepResponse("Invalid Recipe.");
        //Validate Step Description
        var existingStepDescription = await _stepRepository.FindByDescriptionAsync(step.Description);
        if (existingStepDescription != null)
            return new StepResponse("Step already exists.");
        //Update Step
        existingStep.Description = step.Description;
        try 
        {
            //Update Step
            _stepRepository.Update(existingStep);
            //Complete transaction
            await _unitOfWork.CompleteAsync();
            //Return Step
            return new StepResponse(existingStep);
        }
        catch (Exception e)
        {
            //Error Handling
            return new StepResponse($"An error occurred when updating the step: {e.Message}");
        }
    }

    public async Task<StepResponse> DeleteAsync(int stepId)
    {
        var existingStep = await _stepRepository.FindByIdAsync(stepId);
        //Validate Step
        if (existingStep == null)
            return new StepResponse("Step not found.");
        //Delete Step
        try 
        {
            //Delete Step
            _stepRepository.Remove(existingStep);
            //Complete transaction
            await _unitOfWork.CompleteAsync();
            //Return Step
            return new StepResponse(existingStep);
        }
        catch (Exception ex)
        {
            //Error Handling
            return new StepResponse($"An error occurred when deleting the step: {ex.Message}");
        }
    }
}