using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Services.Communication;

public class ProductResponse:BaseResponse<Product>
{
    public ProductResponse(Product resource) : base(resource)
    {
    }

    public ProductResponse(string message) : base(message)
    {
    }
}