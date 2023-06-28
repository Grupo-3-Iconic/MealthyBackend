using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Domain.Services.Communication;

namespace Mealthy.Mealthy.Domain.Service.Communication;

public class MarketResponse : BaseResponse<Market>
{
    public MarketResponse(Market market) : base(market)
    {
    }

    public MarketResponse(string message) : base(message)
    {
    }
    
}