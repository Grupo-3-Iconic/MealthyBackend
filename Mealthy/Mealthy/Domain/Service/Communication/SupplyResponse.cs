using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class SupplyResponse : BaseResponse<Supply>
{
    public SupplyResponse(Supply resource) : base(resource) { }
    public SupplyResponse(string message) : base(message) { }
}