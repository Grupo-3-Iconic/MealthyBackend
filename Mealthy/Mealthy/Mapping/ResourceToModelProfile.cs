using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Resources;

namespace Mealthy.Mealthy.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveIngredientResource, Ingredient>();
        CreateMap<SaveStepResource, Step>();
        CreateMap<SaveRecipeResource, Recipe>();
        CreateMap<SaveSupplyResource, Supply>();
        CreateMap<SaveMarketResource, Market>();
    }
}