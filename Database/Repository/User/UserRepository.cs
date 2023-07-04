using SLVS.Exceptions;

namespace SLVS.Database.Repository.User;

public class UserRepository : Repository, IUserRepository
{
    public UserRepository(SlvsContext db) : base(db)
    {
    }

    public Model.User? CheckLettercode(string lettercode)
    {
        return Db.Users!.FirstOrDefault(x => x.Lettercode == lettercode);
    }

    public Model.User? CheckEmail(string email)
    {
        return Db.Users!.FirstOrDefault(x => x.Email == email);
    }

    public Model.User Login(string lettercode, string password)
    {
        var user = Db.Users!.FirstOrDefault(x => x.Lettercode == lettercode);

        if (user == null) throw new UserNotFoundException();

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) throw new UserNotFoundException();

        return user;
    }
}