namespace SLVS.Database.Model;

public class User
{
    public int Id { get; set; }
    public string Lettercode { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<UserGroup> UserGroups { get; } = new();
    public DateTime Created { get; set; }

    public User()
    {
        Created = DateTime.Now;
    }
}