using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class StepResponse : BaseResponse<Step>
{
    public StepResponse(Step resource) : base(resource) { }
    public StepResponse(string message) : base(message) { }
}