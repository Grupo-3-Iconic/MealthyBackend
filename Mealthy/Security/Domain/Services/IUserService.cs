using Mealthy.Security.Domain.Models;
using Mealthy.Security.Domain.Services.Communication;

namespace Mealthy.Security.Domain.Services;
public interface IUserservice
{
    Task<AuthenticateResponse> Authenticate (AuthenticateRequest model);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync (int id);
    Task RegisterAsync (RegisterRequest model);
    Task UpdateAsync (int id, UpdateRequest model);
    Task DeleteAsync (int id);

}