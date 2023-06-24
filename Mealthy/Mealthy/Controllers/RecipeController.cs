using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;
    public RecipeController(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
    }
    //GET api/v1/recipe
    [HttpGet]
    public async Task<IEnumerable<RecipeResource>> GetAllAsync()
    {
        var recipes = await _recipeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeResource>>(recipes);
        return resources;
    }
}    