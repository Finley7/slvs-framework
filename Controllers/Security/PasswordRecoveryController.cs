using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using SLVS.Database.Model;
using SLVS.Database.Repository.User;
using SLVS.Database.Repository.UserRecoveryToken;
using SLVS.DTO.User;
using SLVS.Security.Attribute.Authentication;
using SLVS.Service.Email;

namespace SLVS.Controllers.Security;

[IsGuest]
public class PasswordRecoveryController : SlvsController
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRecoveryTokenRepository _recoveryTokenRepository;
    private readonly IEmailService _emailService;
    public PasswordRecoveryController(IUserRepository userRepository, IUserRecoveryTokenRepository recoveryTokenRepository, IEmailService emailService)
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
        var urt = new UserRecoveryToken();
        var user = _userRepository.FindBy<User>("Email", f.Email).First();

        if (user != null)
        {
            urt.User = user;

            _recoveryTokenRepository.Create(urt);
            await _emailService.SendEmail("f.siebert@vistacollege.nl", "Wachtwoord vergeten", "Wachtwoord vergeten template komt hier.");
          
        }

        Flasher.Success("Als de gebruiker bestaat, wordt een e-mail verzonden.");
        return new RedirectResult("../Login");
    }
}