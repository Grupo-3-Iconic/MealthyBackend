using Mealthy.Mealthy.Domain.Repositories;
using Mealthy.Shared.Persistence.Contexts;

namespace Mealthy.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}