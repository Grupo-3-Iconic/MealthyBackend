using AutoMapper;
using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Domain.Services;
using Mealthy.Mealthy.Resource;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Mealthy.Mealthy.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    
    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources.ToList();
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var product = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.SaveAsync(product);
        if (!result.Success)
            return BadRequest(result.Message);
        var supplyResource = _mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(supplyResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var product = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.UpdateAsync(id, product);
        if (!result.Success)
            return BadRequest(result.Message);
        var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(productResource);
    }
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _productService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(productResource);
    }
}