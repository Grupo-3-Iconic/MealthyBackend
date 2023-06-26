using Mealthy.Security.Domain.Models;
using Mealthy.Security.Domain.Services.Communication;

namespace Mealthy.Security.Domain.Services;
public interface IUserservice
{
    Task<AuthenticateResponse> Authenticate (AuthenticateRequest request);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync (int id);
    Task<User> GetByIdAndRole(int id, string role);
    Task RegisterAsync (RegisterRequest request);
    Task UpdateAsync (int id, UpdateRequest request);
    Task DeleteAsync (int id);

}