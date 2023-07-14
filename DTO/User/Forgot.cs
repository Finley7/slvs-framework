using System.ComponentModel.DataAnnotations;

namespace SLVS.DTO.User;

public class Forgot : FormModel
{
    [Required] [EmailAddress] public string Email { get; set; }
}