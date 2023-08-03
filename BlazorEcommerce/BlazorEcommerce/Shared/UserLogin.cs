using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Shared;

public class UserLogin
{
    [Required]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
}