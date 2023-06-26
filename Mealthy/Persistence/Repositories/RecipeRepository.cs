using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class RecipeRepository : BaseRepository, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Recipe>> ListAsync()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task AddAsync(Recipe recipe)
    {
        await _context.Recipes.AddAsync(recipe);
    }

    public async Task<Recipe> FindByIdAsync(int id)
    {
        return await _context.Recipes.FindAsync(id);
    }
    public async Task<Recipe> FindByTitleAsync(string title)
    {
        return await _context.Recipes.FirstOrDefaultAsync(r => r.Title == title);
    }
    public void Update(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
    }

    public void Remove(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
    }
}