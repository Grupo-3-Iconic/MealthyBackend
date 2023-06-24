using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class StoreResponse : BaseResponse<Store>
{
    public StoreResponse(Store resource) : base(resource)
    {
    }

    public StoreResponse(string message) : base(message)
    {
    }
}