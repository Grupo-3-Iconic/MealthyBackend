namespace Mealthy.Security.Domain.Services.Communication;
public class AuthenticateResponse
{
    public int Id { get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get;set; }
    public string RUC { get; set; }
    public string storeId { get; set; }
 
    public string Genre { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public string Phone { get; set;}
    public string Role { get; set; }
    public string Token { get; set; }

}