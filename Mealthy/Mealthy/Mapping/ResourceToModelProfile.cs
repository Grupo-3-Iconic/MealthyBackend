using AutoMapper;
using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Resource;

namespace Mealthy.Mealthy.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
    }
    
}