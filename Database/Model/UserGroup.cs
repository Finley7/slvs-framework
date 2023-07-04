namespace SLVS.Database.Model;

public class UserGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Permission> Permissions { get; } = new();
    public List<User> Users { get; } = new();
}