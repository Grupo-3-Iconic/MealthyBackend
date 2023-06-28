using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class MarketRepository : BaseRepository, IMarketRepository
{
    public MarketRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Market>> ListAsync()
    {
        return await _context.Markets.ToListAsync();
    }

    public async Task AddAsync(Market market)
    {
        await _context.Markets.AddAsync(market);
    }

    public async Task<Market> FindByIdAsync(int id)
    {
        return await _context.Markets.FindAsync(id);
    }

    public void Update(Market market)
    {
        _context.Markets.Update(market);
    }

    public void Remove(Market market)
    {
        _context.Markets.Remove(market);
    }
}