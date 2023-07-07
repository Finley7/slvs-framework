using SLVS.Database.Model;
using SLVS.Security.Attribute.Authentication;

namespace SLVS.Security.Attribute.Authorization;

public class HasPermission : SlvsAttribute
{
    public void HandleTask(HttpContext context, User user)
    {
    }
}