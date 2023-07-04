using SLVS.Database.Model;

namespace SLVS.Authentication.Attribute;

public class SlvsAttribute : System.Attribute
{
    public virtual void HandleTask(HttpContext context, User user)
    {
        throw new NotImplementedException("No method has been implemented to handle this attribute.");
    }
}