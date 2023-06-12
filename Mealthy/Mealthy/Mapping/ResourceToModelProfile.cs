using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Resources;

namespace Mealthy.Mealthy.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveIngredienteResource, Ingredient>();
        CreateMap<SaveStepResource, Step>();
        CreateMap<SaveRecipeResource, Recipe>();
    }
}