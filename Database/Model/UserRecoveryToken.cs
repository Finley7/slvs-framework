using System.Security.Cryptography;

namespace SLVS.Database.Model;

public class UserRecoveryToken
{
    public UserRecoveryToken()
    {
        Created = DateTime.Now;
        Expires = Created.AddHours(4);

        var rnd = RandomNumberGenerator.Create();
        var bytes = new byte[32];
        rnd.GetBytes(bytes);

        Token = Convert.ToHexString(bytes);
        Expired = false;
    }

    public int Id { get; set; }
    public string Token { get; set; }
    public User User { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expires { get; set; }
    public bool Expired { get; set; }
}