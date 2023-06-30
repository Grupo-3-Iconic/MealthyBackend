using System.Collections;
using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Mealthy.Domain.Service;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Services;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> GetByStoreId(int id)
    {
        return await _productRepository.FindByStoreIdAsync(id);

    }
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
        
        
    }

    public async Task<ProductResponse> GetByIdAsync(int id)
    {
        var product = await _productRepository.FindByIdAsync(id);
        if (product == null)
            return new ProductResponse("Product dosnt exist");
        return new ProductResponse(product);
    }

    public async Task<ProductResponse> UpdateAsync(int id, Product product)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Product not found.");

        existingProduct.Name = product.Name;

        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while updating the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int id)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Product not found.");

        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ProductResponse($"An error occurred while deleting the product: {e.Message}");
        }
    }

    
}