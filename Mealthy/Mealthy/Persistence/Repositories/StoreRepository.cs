using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class StoreRepository : BaseRepository, IStoreRepository
{
    public StoreRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Store>> ListAsync()
    {
        return await _context.Stores.ToListAsync();
    }

    public async Task AddAsync(Store store)
    {
        await _context.Stores.AddAsync(store);
    }

    public async Task<Store> FindByIdAsync(int id)
    {
        return await _context.Stores.FindAsync(id);
    }

    public void Update(Store store)
    {
        _context.Stores.Update(store);
    }

    public void Remove(Store store)
    {
        _context.Stores.Remove(store);
    }
}