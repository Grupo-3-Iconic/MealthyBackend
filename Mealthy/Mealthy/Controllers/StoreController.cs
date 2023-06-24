using System.Net.Mime;
using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;

    public StoreController(IStoreService storeService, IMapper mapper)
    {
        _storeService = storeService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StoreResponse>), 200)]
    public async Task<IEnumerable<StoreResource>> GetAllAsync()
    {
        var stores = await _storeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);

        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(StoreResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var store = _mapper.Map<SaveStoreResource, Store>(resource);

        var result = await _storeService.SaveAsync(store);

        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Created(nameof(PostAsync), storeResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var store = _mapper.Map<SaveStoreResource, Store>(resource);
        var result = await _storeService.UpdateAsync(id, store);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _storeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResource);
    }
}