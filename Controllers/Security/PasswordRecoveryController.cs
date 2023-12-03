using BCrypt.Net;
using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Templating.Core;
using SLVS.Database.Model;
using SLVS.Database.Repository.User;
using SLVS.Database.Repository.UserRecoveryToken;
using SLVS.DTO.User;
using SLVS.Extensions;
using SLVS.Security.Attribute.Authentication;
using SLVS.Service.Email;

namespace SLVS.Controllers.Security;

[IsGuest]
public class PasswordRecoveryController : SlvsController
{
    private readonly IEmailService _emailService;
    private readonly IUserRecoveryTokenRepository _recoveryTokenRepository;
    private readonly IUserRepository _userRepository;

    public PasswordRecoveryController(IUserRepository userRepository,
        IUserRecoveryTokenRepository recoveryTokenRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _recoveryTokenRepository = recoveryTokenRepository;
        _emailService = emailService;
    }

    public IActionResult Index()
    {
        return View("../Security/Forgot");
    }

    public async Task<RedirectResult> PostForgot(Forgot f)
    {
        var errors = f.Validate();

        if (errors.Count > 0)
        {
            TempData.Put("Errors", errors);
            return new RedirectResult("../PasswordRecovery");
        }

        var urt = new UserRecoveryToken();
        var user = _userRepository.FindBy<User>("Email", f.Email).First();

        if (user != null)
        {
            urt.User = user;

            _recoveryTokenRepository.Create(urt);
            await _emailService.SendEmail(urt.User.Email, "Wachtwoord vergeten",
                await RazorTemplateEngine.RenderAsync("../Email/Forgot", urt));
        }

        Flasher.Success("Als de gebruiker bestaat, wordt een e-mail verzonden.");
        return new RedirectResult("../Login");
    }

    public IActionResult Recover(string id)
    {
        UserRecoveryToken urt;

        try
        {
            urt = _recoveryTokenRepository.FindBy<UserRecoveryToken>("Token", id).Include("User").First();
        } catch (Exception ex)
        {
            Flasher.Danger("This link is invalid!");
            return new RedirectResult("/PasswordRecovery");
        }

        return View("../Security/Recover");
    }

    public RedirectResult PostNewPassword(Recover r)
    {
        var errors = r.Validate();

        if(errors.Count > 0)
        {
            throw new Exception("Went over HTML validation and errors where found");
        }

        var urt = _recoveryTokenRepository.FindBy<UserRecoveryToken>("Token", r.Token).Include("User").First();

        if(null == urt)
        {
            throw new Exception("URT Not found");
        }

        var user = urt.User;

        user.Password = BCrypt.Net.BCrypt.HashPassword(r.NewPassword);
        _userRepository.Update(user);

        Flasher.Success("Your password has been reset. You can login with the new one!");
        return new RedirectResult("../Login");
    }
}