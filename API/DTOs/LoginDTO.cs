using System.ComponentModel.DataAnnotations;

namespace API;

public class LoginDTO
{   [Required]
    public required string username { get; set; }
    [Required]
    public required string password { get; set; }
}
