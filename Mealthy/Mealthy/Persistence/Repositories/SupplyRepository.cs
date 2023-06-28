using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class SupplyRepository : BaseRepository, ISupplyRepository
{
    public SupplyRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Supply>> ListAsync()
    {
        return await _context.Supplies.ToListAsync();
    }

    public async Task AddAsync(Supply supply)
    {
        await _context.Supplies.AddAsync(supply);
    }

    public async Task<Supply> FindByIdAsync(int id)
    {
        return await _context.Supplies.FindAsync(id);
    }

    public async Task<Supply> FindByNameAsync(string name)
    {
        return await _context.Supplies.FirstOrDefaultAsync(s => s.Name == name);
    }

    public void Update(Supply supply)
    {
        _context.Supplies.Update(supply);
    }

    public void Remove(Supply supply)
    {
        _context.Supplies.Remove(supply);
    }
}