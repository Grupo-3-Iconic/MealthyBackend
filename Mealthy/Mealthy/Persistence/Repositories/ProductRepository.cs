using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class ProductRepository:BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> LisTask()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }
    public async Task<Product> FindByIdAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }

    public Task<Product> FindByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product); 
    }
    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}