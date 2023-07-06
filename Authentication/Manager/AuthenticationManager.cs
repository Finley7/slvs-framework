using System.Globalization;
using Newtonsoft.Json;
using SLVS.Database.Model;
using SLVS.Middleware;

namespace SLVS.Authentication.Manager;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly HttpContext? _context = new HttpContextAccessor().HttpContext;

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
}