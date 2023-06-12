using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class IngredientRepository : BaseRepository, IIngredientRepository
{
    public IngredientRepository(AppDbContext context) : base(context) { }
    
    public async Task<IEnumerable<Ingredient>> ListAsync()
    {
        return await _context.Ingredients.Include(p=>p.Recipe).ToListAsync();
    }
    public async Task AddAsync(Ingredient ingredient)
    {
        await _context.Ingredients.AddAsync(ingredient);
    }
    public async Task<Ingredient> FindByIdAsync(int ingredientId)
    {
        return await _context.Ingredients
            .Include(p=>p.Recipe)
            .FirstOrDefaultAsync(i => i.Id == ingredientId);
    }
    public async Task<Ingredient> FindByNameAsync(string name)
    {
        return await _context.Ingredients
            .Include(p=>p.Recipe)
            .FirstOrDefaultAsync(i => i.Name == name);
    }
    public async Task<IEnumerable<Ingredient>> FindByRecipeIdAsync(int recipeId)
    {
        return await _context.Ingredients
            .Where(i => i.RecipeId == recipeId)
            .Include(p=>p.Recipe)
            .ToListAsync();
    }
    public void Update(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
    }
    public void Remove(Ingredient ingredient)
    {
        _context.Ingredients.Remove(ingredient);
    }
}