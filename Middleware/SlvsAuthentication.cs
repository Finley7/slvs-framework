using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using SLVS.Database.Model;

namespace SLVS.Middleware;

public class SlvsAuthentication
{
    private readonly ILogger<SlvsAuthentication> _logger;
    private readonly RequestDelegate _next;

    public SlvsAuthentication(RequestDelegate next, ILogger<SlvsAuthentication> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // check which user is logged in.
        
        var userString = context.Session.GetString("User") ?? "";
        var user = JsonConvert.DeserializeObject<User>(userString) ?? new AnonymousUser();

        // Find if the controllers has a valid attribute
        var endpointFeature = context.Features.Get<IEndpointFeature>();
        var attr = endpointFeature?.Endpoint?.Metadata
            .OfType<Attribute>()
            .FirstOrDefault(x => x.GetType().Namespace == "SLVS.Security.Attribute.Authentication");

        if (attr != null)
        {
            bool stop = false;

            switch (attr.ToString())
            {
                case "SLVS.Security.Attribute.Authentication.IsLoggedIn":
                    if (user.GetType() == typeof(AnonymousUser))
                    {
                        context.Response.Redirect("/Login");
                        stop = true;
                    }
                    break;
                case "SLVS.Security.Attribute.Authentication.IsGuest":
                    if (user.GetType() != typeof(AnonymousUser))
                    {
                        context.Response.Redirect("/Dashboard");
                        stop = true;
                    }
                    break;
            }

            if (stop) return;
        }

        _logger.Log(LogLevel.Information, $"Called attribute {attr?.GetType()} with user {user.Lettercode}");

        // Call the next delegate/middleware in the pipeline. 
        await _next(context);
    }
}

public static class SlvsAuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseSlvsAuthentication(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SlvsAuthentication>();
    }
}

public class AnonymousUser : User
{
    public AnonymousUser()
    {
        Lettercode = "ANON.";
        Email = "n/a";
        Password = "n/a";
        UserGroups.Add(new UserGroup
        {
            Name = "GUEST",
            Description = "Guest user"
        });
    }
}