using AutoMapper;
using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Resource;

namespace Mealthy.Mealthy.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Product, ProductResource>();
    }
}