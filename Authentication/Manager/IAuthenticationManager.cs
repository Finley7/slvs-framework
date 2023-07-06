using SLVS.Database.Model;

namespace SLVS.Authentication.Manager;

public interface IAuthenticationManager
{
    public User GetUser();
    public void SetUser(User user);
}