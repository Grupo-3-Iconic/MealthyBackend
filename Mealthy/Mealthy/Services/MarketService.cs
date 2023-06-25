using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class MarketService : IMarketService
{
    private readonly IMarketRepository _marketRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public MarketService(IMarketRepository marketRepository, IUnitOfWork unitOfWork)
    {
        _marketRepository = marketRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Market>> ListAsync()
    {
        return await _marketRepository.ListAsync();
    }

    public async Task<MarketResponse> SaveAsync(Market market)
    {
        try
        {
            await _marketRepository.AddAsync(market);
            await _unitOfWork.CompleteAsync();
            return new MarketResponse(market);
        }
        catch (Exception e)
        {
            return new MarketResponse($"An error occurred while saving the market: {e.Message}");
        }
    }

    public async Task<MarketResponse> UpdateAsync(int id, Market market)
    {
        var existingMarket = await _marketRepository.FindByIdAsync(id);
        
        if (existingMarket == null)
            return new MarketResponse("Market not found.");

        existingMarket.storeName = market.storeName;

        try
        {
            _marketRepository.Update(existingMarket);
            await _unitOfWork.CompleteAsync();

            return new MarketResponse(existingMarket);
        }
        catch (Exception e)
        {
            return new MarketResponse($"An error occurred while updating the market: {e.Message}");
        }
    }

    public async Task<MarketResponse> DeleteAsync(int id)
    {
        var existingMarket = await _marketRepository.FindByIdAsync(id);

        if (existingMarket == null)
            return new MarketResponse("Market not found.");

        try
        {
            _marketRepository.Remove(existingMarket);
            await _unitOfWork.CompleteAsync();

            return new MarketResponse(existingMarket);
        }
        catch (Exception e)
        {
            return new MarketResponse($"An error occurred while deleting the market: {e.Message}");
        }
    }
}