using Mealthy.Security.Domain.Models;

namespace Mealthy.Security.Domain.Repositories;
public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync (User user );
    Task <User> FindByIdAsync (int id);
    Task <User> FindByUsernameAsync(string username);
    public bool ExistsByUsername (string username);
    User FindById(int id);
    Task<User> FindByIdAndRoleAsync(int id, string role);
    void Update(User user);
    void Remove(User user);
}