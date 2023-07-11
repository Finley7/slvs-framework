using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using SLVS.Security.Attribute.Authentication;

namespace SLVS.Controllers.Security
{
    [IsLoggedIn]
    public class ProfileController : SlvsController
    {
        [HttpGet("/Profile/Logout")]
        public RedirectResult Logout()
        {
            AuthenticationManager.DestroyUser();
            Flasher.Success("Je bent succesvol uitgelogd");

            return new RedirectResult("../Login");
        }
    }
}
