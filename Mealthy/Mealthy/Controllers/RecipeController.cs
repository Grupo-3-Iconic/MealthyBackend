using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
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

    //POST api/v1/recipe
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRecipeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var recipe = _mapper.Map<SaveRecipeResource, Recipe>(resource);
        var result = await _recipeService.SaveAsync(recipe);
        if (!result.Success)
            return BadRequest(result.Message);
        var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
        return Ok(recipeResource);
    }
    //PUT api/v1/recipe/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecipeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var recipe = _mapper.Map<SaveRecipeResource, Recipe>(resource);
        var result = await _recipeService.UpdateAsync(id, recipe);
        if (!result.Success)
            return BadRequest(result.Message);
        var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
        return Ok(recipeResource);
    }
    //DELETE api/v1/recipe/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _recipeService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
        return Ok(recipeResource);
    }
}