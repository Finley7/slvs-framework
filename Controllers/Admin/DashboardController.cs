using Microsoft.AspNetCore.Mvc;
using SLVS.Security.Attribute.Authentication;

namespace SLVS.Controllers.Admin;

[IsLoggedIn]
public class DashboardController : SlvsController
{
    public IActionResult Index()
    {
        if (AuthorizationManager.IsAuthorized("test_permission")) Console.WriteLine("Hello world");
        return View();
    }
}