using SLVS.Database.Model;

namespace SLVS.Security.Manager.Authentication;

public interface IAuthenticationManager
{
    /// <summary>
    ///     Gets the current authenticated user. If no user is authenticated it will return the default anonymous object.
    /// </summary>
    /// <returns>Current signed in user object</returns>
    public User GetUser();

    /// <summary>
    ///     Sets the current authenticated user. Overwrites the current logged-in user.
    /// </summary>
    /// <param name="user">The user object that has to be remembered</param>
    public void SetUser(User user);

    /// <summary>
    ///     Destroys the current session and sets a last logged in user flag.
    /// </summary>
    public void DestroyUser();

    /// <summary>
    ///     Fetches the last known username
    /// </summary>
    /// <returns>The last known username</returns>
    public string? LastLoginName();

    /// <summary>
    ///     Gets the last session time
    /// </summary>
    /// <returns>DateTime object of latest session</returns>
    public DateTime? PreviousSessionTime();

    /// <summary>
    ///     Gets the time when the user was logged in
    /// </summary>
    /// <returns>DateTime object with session creation date</returns>
    public DateTime? LastLogin();

    /// <summary>
    ///     Checks if the current session is authenticated.
    /// </summary>
    /// <returns>Returns whether the user session is filled with an anonymous user or not</returns>
    public bool IsLoggedIn();
}