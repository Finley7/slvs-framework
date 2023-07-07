namespace SLVS.Security.Manager.Authorization;

public interface IAuthorizationManager
{
    /// <summary>
    ///     Check whether the user is authorized or not
    /// </summary>
    /// <param name="permission">The name of the permission in the permissions table</param>
    /// <returns>True if authorized and false if not</returns>
    public bool IsAuthorized(string permission);
}