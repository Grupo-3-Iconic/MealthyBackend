using AutoMapper;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Resources;

namespace Mealthy.Mealthy.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Recipe, RecipeResource>();
        CreateMap<Ingredient, IngredientResource>();
        CreateMap<Step, StepResource>();
        CreateMap<Supply, SupplyResource>();
        CreateMap<Market, MarketResource>();
    }
}