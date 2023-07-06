using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using SLVS.Authentication.Manager;

namespace SLVS.Controllers;

public abstract class SlvsController : Controller
{
    protected IAuthenticationManager AuthenticationManager =>
        HttpContext.RequestServices.GetService<IAuthenticationManager>();

    protected IFlasher Flasher => HttpContext.RequestServices.GetService<IFlasher>();
}