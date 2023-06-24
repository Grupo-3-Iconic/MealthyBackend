using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
    {
        _storeRepository = storeRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Store>> ListAsync()
    {
        return await _storeRepository.ListAsync();
    }

    public async Task<StoreResponse> SaveAsync(Store store)
    {
        try
        {
            await _storeRepository.AddAsync(store);
            await _unitOfWork.CompleteAsync();
            return new StoreResponse(store);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error ocurred while saving the Store: {e.Message}");
        }
    }

    public async Task<StoreResponse> UpdateAsync(int id, Store store)
    {
        var existingStore = await _storeRepository.FindByIdAsync(id);

        if (existingStore == null)
        {
            return new StoreResponse("Store not found");
        }
        existingStore.name = store.name;
        existingStore.description = store.description;
        existingStore.photoUrl = store.photoUrl;
        existingStore.ProductsId = store.ProductsId;

        try
        {
            _storeRepository.Update(existingStore);
            await _unitOfWork.CompleteAsync();

            return new StoreResponse(existingStore);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error ocurred while updating the store: {e.Message}");
        }
    }

    public async Task<StoreResponse> DeleteAsync(int id)
    {
        var existingStore = await _storeRepository.FindByIdAsync(id);

        if (existingStore == null)
            return new StoreResponse("Store not found");

        try
        {
            _storeRepository.Remove(existingStore);
            await _unitOfWork.CompleteAsync();

            return new StoreResponse(existingStore);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error ocurred while deleting the store: {e.Message}");
        }
    }
}