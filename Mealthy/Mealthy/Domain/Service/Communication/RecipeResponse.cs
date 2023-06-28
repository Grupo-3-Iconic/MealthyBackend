using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class RecipeResponse : BaseResponse<Recipe>
{
    public RecipeResponse(Recipe resource) : base(resource) { }
    public RecipeResponse(string message) : base(message) { }
}