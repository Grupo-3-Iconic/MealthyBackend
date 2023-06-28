using System.Net.Mime;
using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MarketController : ControllerBase
{
    private readonly IMarketService _marketService;
    private readonly IMapper _mapper;

    public MarketController(IMarketService marketService, IMapper mapper)
    {
        _marketService = marketService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MarketResource>), 200)]
    public async Task<IEnumerable<MarketResource>> GetAllAsync()
    {
        var markets = await _marketService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Market>, IEnumerable<MarketResource>>(markets);

        return resources;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(MarketResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveMarketResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var market = _mapper.Map<SaveMarketResource, Market>(resource);

        var result = await _marketService.SaveAsync(market);

        if (!result.Success)
            return BadRequest(result.Message);

        var marketResource = _mapper.Map<Market, MarketResource>(result.Resource);

        return Created(nameof(PostAsync), marketResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMarketResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var market = _mapper.Map<SaveMarketResource, Market>(resource);
        var result = await _marketService.UpdateAsync(id, market);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var marketResource = _mapper.Map<Market, MarketResource>(result.Resource);

        return Ok(marketResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _marketService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var marketResource = _mapper.Map<Market, MarketResource>(result.Resource);

        return Ok(marketResource);
    }
    
}