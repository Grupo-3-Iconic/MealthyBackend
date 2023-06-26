using Mealthy.Security.Domain.Models;
using Mealthy.Security.Domain.Repositories;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Security.Persistence.Repositories;

public class UserRepository :BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {

    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.users.ToListAsync();
    }
    public async Task AddAsync(User user)
    {
        await _context.users.AddAsync(user);
    }
    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.users.FindAsync(id);
    }
    public async Task<User> FindByUsernameAsync(string username)
    {
        return await _context.users.SingleOrDefaultAsync 
        (x=> x.Username==username);
    }
    public bool ExistsByUsername(string username)
    {
        return _context.users.Any(x=> x.Username==username);
    }
    public User FindById(int id)
    {
        return _context.users.Find(id);
    }

    public async Task<User> FindByIdAndRoleAsync(int id, string role)
    {
        return await _context.users.SingleOrDefaultAsync(x => x.Id == id && x.Role == role);
    }

    public void Update(User user)
    {
        _context.users.Update(user);
    }
    public void Remove(User user)
    {
        _context.users.Remove(user);
    }

    
    }