using System.ComponentModel.DataAnnotations;

namespace SLVS.DTO.User
{
    public class Recover : FormModel
    {
        [Required] public required string NewPassword { get; set; }
        [Required] public required string Token { get; set; }

    }
}
