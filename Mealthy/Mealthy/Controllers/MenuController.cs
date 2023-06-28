using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Resources;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    private readonly IMapper _mapper;

    public MenuController(IMenuService menuService, IMapper mapper)
    {
        _menuService = menuService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MenuResource>> GetAllAsync()
    {
        var menus = await _menuService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Menu>, IEnumerable<MenuResource>>(menus);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMenuResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var menu = _mapper.Map<SaveMenuResource, Menu>(resource);
        var result = await _menuService.SaveAsync(menu);

        if (!result.Success)
            return BadRequest(result.Message);

        var menuResource = _mapper.Map<Menu, MenuResource>(result.Resource);
        return Ok(menuResource);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMenuResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var menu = _mapper.Map<SaveMenuResource, Menu>(resource);
        var result = await _menuService.UpdateAsync(id, menu);

        if (!result.Success)
            return BadRequest(result.Message);

        var menuResource = _mapper.Map<Menu, MenuResource>(result.Resource);
        return Ok(menuResource);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _menuService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var menuResource = _mapper.Map<Menu, MenuResource>(result.Resource);
        return Ok(menuResource);
    }
}