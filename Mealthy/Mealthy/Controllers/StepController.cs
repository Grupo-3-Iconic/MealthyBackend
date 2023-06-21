using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class StepController : ControllerBase
{
    private readonly IStepService _stepService;
    private readonly IMapper _mapper;
    public StepController(IStepService stepService, IMapper mapper)
    {
        _stepService = stepService;
        _mapper = mapper;
    }
    //GET api/v1/step
    [HttpGet]
    public async Task<IEnumerable<StepResource>> GetAllAsync()
    {
        var steps = await _stepService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Step>, IEnumerable<StepResource>>(steps);
        return resources;
    }
    //POST api/v1/step
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveStepResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var step = _mapper.Map<SaveStepResource, Step>(resource);
        var result = await _stepService.SaveAsync(step);
        if (!result.Success)
            return BadRequest(result.Message);
        var stepResource = _mapper.Map<Step, StepResource>(result.Resource);
        return Ok(stepResource);
    }
    //PUT api/v1/step/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStepResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var step = _mapper.Map<SaveStepResource, Step>(resource);
        var result = await _stepService.UpdateAsync(id, step);
        if (!result.Success)
            return BadRequest(result.Message);
        var stepResource = _mapper.Map<Step, StepResource>(result.Resource);
        return Ok(stepResource);
    }
    //DELETE api/v1/step/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _stepService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var stepResource = _mapper.Map<Step, StepResource>(result.Resource);
        return Ok(stepResource);
    }
}