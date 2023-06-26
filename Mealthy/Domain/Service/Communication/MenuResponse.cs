using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class MenuResponse : BaseResponse<Menu>
{
    public MenuResponse(Menu resource) : base(resource) {}
    public MenuResponse(string message) : base(message) {}
}