using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SLVS.Authentication.Attribute;
using SLVS.Database.Repository.User;
using SLVS.DTO.User;

namespace SLVS.Controllers.Security;

[IsGuest]
public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;

    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View("../Security/Login");
    }

    [HttpPost]
    public RedirectResult Login(Login login)
    {
        var user = _userRepository.Login(login.Lettercode, login.Password);
        HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));

        return new RedirectResult("/Dashboard");
    }
}