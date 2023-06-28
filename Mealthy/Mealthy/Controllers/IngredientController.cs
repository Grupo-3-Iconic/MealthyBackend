using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    private readonly IMapper _mapper;

    public IngredientController(IIngredientService ingredientService, IMapper mapper)
    {
        _ingredientService = ingredientService;
        _mapper = mapper;
    }
    
    // GET: api/Ingredients
    [HttpGet]
    public async Task<IEnumerable<IngredientResource>> GetAllAsync()
    {
        var ingredients = await _ingredientService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredients);
        return resources.ToList();
    }
    
    // POST: api/Ingredients
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveIngredientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
        var result = await _ingredientService.SaveAsync(ingredient);
        if (!result.Success)
            return BadRequest(result.Message);
        var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
        return Ok(ingredientResource);
    }
    // PUT: api/Ingredients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIngredientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
        var result = await _ingredientService.UpdateAsync(id, ingredient);
        if (!result.Success)
            return BadRequest(result.Message);
        var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
        return Ok(ingredientResource);
    }
    // DELETE: api/Ingredients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _ingredientService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
        return Ok(ingredientResource);
    }
}