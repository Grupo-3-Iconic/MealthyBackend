
using Mealthy.Security.Domain.Models;

namespace Mealthy.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
    
 

}