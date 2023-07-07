using Microsoft.EntityFrameworkCore;
using SLVS.Database.Model;
using SLVS.Database.Repository.User;
using SLVS.Exceptions;
using SLVS.Security.Manager.Authentication;

namespace SLVS.Security.Manager.Authorization;

public class AuthorizationManager : IAuthorizationManager
{
    private readonly IAuthenticationManager _authenticationManager;
    private readonly IUserRepository _userRepository;

    public AuthorizationManager(IUserRepository userRepository, IAuthenticationManager authenticationManager)
    {
        _userRepository = userRepository;
        _authenticationManager = authenticationManager;

        if (authenticationManager.GetUser().Lettercode == "ANON.") throw new NotAuthenticatedException();
    }

    public bool IsAuthorized(string permission)
    {
        return GetPermissions().Any(p => p.Name == permission);
    }

    private List<Permission> GetPermissions()
    {
        var user = _userRepository.FindBy<User>("lettercode", _authenticationManager.GetUser().Lettercode)
            .Include("UserGroups").Include("UserGroups.Permissions").First();

        var permissions = new List<Permission>();

        foreach (var ug in user.UserGroups)
        foreach (var p in ug.Permissions)
            permissions.Add(p);

        return permissions;
    }
}