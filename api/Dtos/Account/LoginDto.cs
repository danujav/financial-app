using System.ComponentModel.DataAnnotations;

namespace api;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
}
