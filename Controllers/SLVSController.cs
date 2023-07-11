using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using SLVS.Security.Manager.Authentication;
using SLVS.Security.Manager.Authorization;
using System.Runtime.CompilerServices;

namespace SLVS.Controllers;

public abstract class SlvsController : Controller
{
    protected IAuthenticationManager AuthenticationManager =>
        HttpContext.RequestServices.GetService<IAuthenticationManager>();

    protected IAuthorizationManager AuthorizationManager =>
        HttpContext.RequestServices.GetService<IAuthorizationManager>();

    protected IFlasher Flasher => HttpContext.RequestServices.GetService<IFlasher>();
}