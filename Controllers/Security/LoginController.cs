using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using SLVS.Database.Repository.User;
using SLVS.DTO.User;
using SLVS.Exceptions;
using SLVS.Security.Attribute.Authentication;

namespace SLVS.Controllers.Security;

[IsGuest]
public class LoginController : SlvsController
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
        try
        {
            var user = _userRepository.Login(login.Lettercode, login.Password);
            AuthenticationManager.SetUser(user);
        }
        catch (UserNotFoundException e)
        {
            Flasher.Danger("Invalid credentials provided");
            return new RedirectResult("/Login");
        }

        return new RedirectResult("/Dashboard");
    }
}