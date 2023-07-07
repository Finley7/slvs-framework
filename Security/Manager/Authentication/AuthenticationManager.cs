using System.Globalization;
using Newtonsoft.Json;
using SLVS.Database.Model;
using SLVS.Middleware;

namespace SLVS.Security.Manager.Authentication;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly HttpContext? _context;

    public AuthenticationManager(IHttpContextAccessor httpContextAccessor)
    {
        _context = httpContextAccessor.HttpContext;
    }

    public User GetUser()
    {
        var userStr = _context?.Session.GetString("User") ?? "";
        if (userStr == "") return new AnonymousUser();

        return JsonConvert.DeserializeObject<User>(userStr) ?? new AnonymousUser();
    }

    public void SetUser(User user)
    {
        var userStr = JsonConvert.SerializeObject(user);
        _context?.Session.SetString("User", userStr);
        _context?.Session.SetString("LoggedInTime", DateTime.Now.ToString(CultureInfo.CurrentCulture));
    }

    public void DestroyUser()
    {
        _context?.Session.SetString("LastKnownUsername", GetUser().Lettercode);
        _context?.Session.Remove("User");
        _context?.Session.Remove("LoggedInTime");
        _context?.Session.SetString("LastLogin", DateTime.Now.ToString(CultureInfo.CurrentCulture));
    }

    public string? LastLoginName()
    {
        return _context?.Session.GetString("LastKnownUsername");
    }

    public DateTime? PreviousSessionTime()
    {
        return DateTime.Parse(_context?.Session.GetString("LastLogin") ?? string.Empty);
    }

    public DateTime? LastLogin()
    {
        return DateTime.Parse(_context?.Session.GetString("LoggedInTime") ?? string.Empty);
    }

    public bool IsLoggedIn()
    {
        return GetUser().Lettercode != "ANON.";
    }
}