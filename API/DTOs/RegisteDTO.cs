using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisteDTO
{
    [Required] //data annotations
    [MaxLength(100)]
    public required string Username{get;set;}
    [Required]
    public required string Password{get;set;}
}
