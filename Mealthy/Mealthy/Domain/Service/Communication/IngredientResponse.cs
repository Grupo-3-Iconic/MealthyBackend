using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class IngredientResponse : BaseResponse<Ingredient>
{
    public IngredientResponse(Ingredient resource) : base(resource) { }
    public IngredientResponse(string message) : base(message) { }
}