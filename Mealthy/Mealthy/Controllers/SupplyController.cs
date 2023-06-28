using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("/api/v1/pantry")]
public class SupplyController : ControllerBase
{
    private readonly ISupplyService _supplyService;
    private readonly IMapper _mapper;
    
    public SupplyController(ISupplyService supplyService, IMapper mapper)
    {
        _supplyService = supplyService;
        _mapper = mapper;
    }
    
    // GET: api/pantry
    [HttpGet]
    public async Task<IEnumerable<SupplyResource>> GetAllAsync()
    {
        var supplies = await _supplyService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyResource>>(supplies);
        return resources.ToList();
    }
    // POST: api/pantry
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupplyResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var supply = _mapper.Map<SaveSupplyResource, Supply>(resource);
        var result = await _supplyService.SaveAsync(supply);
        if (!result.Success)
            return BadRequest(result.Message);
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource);
        return Ok(supplyResource);
    }
    // PUT: api/pantry/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupplyResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var supply = _mapper.Map<SaveSupplyResource, Supply>(resource);
        var result = await _supplyService.UpdateAsync(id, supply);
        if (!result.Success)
            return BadRequest(result.Message);
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource);
        return Ok(supplyResource);
    }
    // DELETE: api/pantry/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _supplyService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var supplyResource = _mapper.Map<Supply, SupplyResource>(result.Resource);
        return Ok(supplyResource);
    }

}