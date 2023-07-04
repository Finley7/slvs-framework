using Microsoft.AspNetCore.Mvc;
using SLVS.Authentication.Attribute;

namespace SLVS.Controllers.Admin;

[IsLoggedIn]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
