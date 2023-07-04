namespace SLVS.Database.Repository.User;

public interface IUserRepository : IRepository
{
    public Model.User? CheckLettercode(string username);
    public Model.User? CheckEmail(string email);
    public Model.User Login(string email, string password);
}