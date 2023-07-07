using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using SLVS.Security.Manager.Authentication;
using SLVS.Security.Manager.Authorization;

namespace SLVS.Controllers;

public abstract class SlvsController : Controller
{
    protected IAuthenticationManager AuthenticationManager =>
        HttpContext.RequestServices.GetService<IAuthenticationManager>();

    protected IAuthorizationManager AuthorizationManager =>
        HttpContext.RequestServices.GetService<IAuthorizationManager>();

    protected IFlasher Flasher => HttpContext.RequestServices.GetService<IFlasher>();
}