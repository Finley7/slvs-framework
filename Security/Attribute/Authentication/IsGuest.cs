using SLVS.Database.Model;
using SLVS.Middleware;

namespace SLVS.Security.Attribute.Authentication;

public class IsGuest : SlvsAttribute
{
    public override void HandleTask(HttpContext context, User user)
    {
        if (user.GetType() != typeof(AnonymousUser)) context.Response.Redirect("/Dashboard");
    }
}