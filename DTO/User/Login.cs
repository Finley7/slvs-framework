using System.ComponentModel.DataAnnotations;

namespace SLVS.DTO.User;

public class Login
{
    [Required] public string Lettercode { get; set; }

    [Required] public string Password { get; set; }
}