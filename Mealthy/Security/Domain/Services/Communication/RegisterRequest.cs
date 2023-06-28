using System.ComponentModel.DataAnnotations;

namespace Mealthy.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string FirstName {get; set; }
    [Required] public string LastName { get; set; }
    public string Genre { get; set; }
    public string Birthday { get; set; }
    public string RUC { get; set; }
    public int storeId {get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Phone { get; set; }
    [Required] public string Role { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }

}