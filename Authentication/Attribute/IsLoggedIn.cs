using SLVS.Database.Model;
using SLVS.Middleware;

namespace SLVS.Authentication.Attribute;

public class IsLoggedIn : SlvsAttribute
{
    public override void HandleTask(HttpContext context, User user)
    {
        if (user.GetType() == typeof(AnonymousUser))
        {
            context.Response.Redirect("/Login");
        }
    }
}