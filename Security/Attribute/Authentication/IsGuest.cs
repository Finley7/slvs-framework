using SLVS.Database.Model;
using SLVS.Middleware;

namespace SLVS.Security.Attribute.Authentication;

public class IsGuest : SlvsAttribute
{
    public override void HandleTask(HttpContext context, User user)
    {
        
    }
}