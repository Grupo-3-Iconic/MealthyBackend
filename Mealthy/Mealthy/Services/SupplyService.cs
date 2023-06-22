using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class SupplyService : ISupplyService
{
    private readonly ISupplyRepository _supplyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public SupplyService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork)
    {
        _supplyRepository = supplyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Supply>> ListAsync()
    {
        return await _supplyRepository.ListAsync();
    }

    public async Task<SupplyResponse> SaveAsync(Supply supply)
    {
        //Validate Supply Name
        var existingSupply = await _supplyRepository.FindByNameAsync(supply.Name);
        if (existingSupply != null)
            return new SupplyResponse("Supply already exists.");
        try
        {
            await _supplyRepository.AddAsync(supply);
            await _unitOfWork.CompleteAsync();
            return new SupplyResponse(supply);
        }
        catch (Exception e)
        {
            return new SupplyResponse($"An error occurred when saving the supply: {e.Message}");
        }
    }

    public async Task<SupplyResponse> UpdateAsync(int id, Supply supply)
    {
        //validate Supply
        var existingSupply = await _supplyRepository.FindByIdAsync(id);
        if (existingSupply == null)
            return new SupplyResponse("Supply not found.");
        //validate Supply Name
        var existingSupplyName = await _supplyRepository.FindByNameAsync(supply.Name);
        if (existingSupplyName != null && existingSupplyName.Id != id)
            return new SupplyResponse("Supply already exists.");
        //Update Supply
        existingSupply.Name = supply.Name;
        existingSupply.Quantity = supply.Quantity;
        existingSupply.Unit = supply.Unit;
        try
        {
            _supplyRepository.Update(existingSupply);
            await _unitOfWork.CompleteAsync();
            return new SupplyResponse(existingSupply);
        }
        catch (Exception e)
        {
            return new SupplyResponse($"An error occurred when updating the supply: {e.Message}");
        }

    }

    public async Task<SupplyResponse> DeleteAsync(int id)
    {
        //validate Supply
        var existingSupply = await _supplyRepository.FindByIdAsync(id);
        if (existingSupply == null)
            return new SupplyResponse("Supply not found.");
        //Delete Supply
        try
        {
            _supplyRepository.Remove(existingSupply);
            await _unitOfWork.CompleteAsync();
            return new SupplyResponse(existingSupply);
        }
        catch (Exception e)
        {
            return new SupplyResponse($"An error occurred when deleting the supply: {e.Message}");
        }
    }
}