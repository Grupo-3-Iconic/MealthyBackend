using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class ProductResponse:BaseResponse<Product>
{
    public ProductResponse(Product resource) : base(resource)
    {
    }

    public ProductResponse(string message) : base(message)
    {
    }
}