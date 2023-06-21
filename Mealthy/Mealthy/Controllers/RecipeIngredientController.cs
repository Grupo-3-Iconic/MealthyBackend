using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("api/v1/recipes/{recipeId}/ingredients")]
public class RecipeIngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    private readonly IMapper _mapper;

    public RecipeIngredientController(IIngredientService ingredientService, IMapper mapper)
    {
        _ingredientService = ingredientService;
        _mapper = mapper;
    }
    //GET api/v1/recipes/{recipeId}/ingredients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IngredientResource>>> GetIngredients(int recipeId)
    {
        var ingredients = await _ingredientService.ListByRecipeIdAsync(recipeId);
        var ingredientResources = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredients);
        return Ok(ingredientResources);
    }

}