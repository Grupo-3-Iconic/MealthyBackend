using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class StepRepository : BaseRepository, IStepRepository
{
    public StepRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Step>> ListAsync()
    {
        return await _context.Steps.Include(p=>p.Recipe).ToListAsync();
    }
    public async Task AddAsync(Step step)
    {
        await _context.Steps.AddAsync(step);
    }
    public async Task<Step> FindByIdAsync(int stepId)
    {
        return await _context.Steps
            .Include(p=>p.Recipe)
            .FirstOrDefaultAsync(p=>p.Id == stepId);
    }
    public async Task<Step> FindByDescriptionAsync(string description)
    {
        return await _context.Steps
            .Include(p => p.Recipe)
            .FirstOrDefaultAsync(i => i.Description == description);
    }
    public async Task<IEnumerable<Step>> FindByRecipeIdAsync(int id)
    {
        return await _context.Steps
            .Where(s => s.RecipeId == id)
            .Include(p=>p.Recipe)
            .ToListAsync();
    }
    public void Update(Step step)
    {
        _context.Steps.Update(step);
    }
    public void Remove(Step step)
    {
        _context.Steps.Remove(step);
    }
}