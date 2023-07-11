using System.ComponentModel.DataAnnotations;

namespace SLVS.DTO.User;

public class Forgot
{
    [Required] [EmailAddress] public string Email { get; set; }
}