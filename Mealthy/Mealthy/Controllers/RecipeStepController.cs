using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("api/v1/recipes/{recipeId}/steps")]
public class RecipeStepController : ControllerBase
{
    private readonly IStepService _stepService;
    private readonly IMapper _mapper;

    public RecipeStepController(IStepService stepService, IMapper mapper)
    {
        _stepService = stepService;
        _mapper = mapper;
    }
    //GET api/v1/recipes/{recipeId}/steps
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StepResource>>> GetSteps(int recipeId)
    {
        var steps = await _stepService.ListByRecipeIdAsync(recipeId);
        var stepResources = _mapper.Map<IEnumerable<Step>, IEnumerable<StepResource>>(steps);
        return Ok(stepResources);
    }
}