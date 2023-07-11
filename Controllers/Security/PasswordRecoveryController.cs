using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using SLVS.Database.Model;
using SLVS.DTO.User;
using SLVS.Security.Attribute.Authentication;

namespace SLVS.Controllers.Security;

[IsGuest]
public class PasswordRecoveryController : SlvsController
{
    public IActionResult Index()
    {
        return View("../Security/Forgot");
    }

    public RedirectResult PostForgot(Forgot f)
    {
        var urt = new UserRecoveryToken();

        Flasher.Success("It has been done..");
        return new RedirectResult("../Security/Forgot");
    }
}