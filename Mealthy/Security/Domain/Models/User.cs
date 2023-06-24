
using System.Text.Json.Serialization;

namespace Mealthy.Security.Domain.Models;

public class User{
    public int Id{get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Username {get;set;}
    public string Genre { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    [JsonIgnore]
    public string PasswordHash{get;set;}

}