using Microsoft.AspNetCore.Mvc;
using SLVS.Authentication.Attribute;

namespace SLVS.Controllers.Admin;

[IsLoggedIn]
public class DashboardController : SlvsController
{
    public IActionResult Index()
    {
        return View();
    }
}