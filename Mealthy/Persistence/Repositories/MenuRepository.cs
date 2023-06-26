using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Mealthy.Persistence.Repositories;

public class MenuRepository : BaseRepository, IMenuRepository
{
    public MenuRepository(AppDbContext context) : base(context) {}


    public async Task<IEnumerable<Menu>> ListAsync()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task AddAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
    }

    public async Task<Menu> FindByIdAsync(int id)
    {
        return await _context.Menus.FindAsync(id);
    }

    public async Task<Menu> FindByTitleAsync(string title)
    {
        return await _context.Menus.FirstOrDefaultAsync(r => r.Title == title);
    }

    public void Update(Menu menu)
    {
        _context.Menus.Update(menu);
    }

    public void Remove(Menu menu)
    {
        _context.Menus.Remove(menu);
    }
}