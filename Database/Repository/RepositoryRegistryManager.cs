using System.Reflection;

namespace SLVS.Database.Repository;

public static class RepositoryRegistryManager
{
    public static IServiceCollection UseSlvsRepositories(
        this IServiceCollection service)
    {
        var repos = typeof(IRepository).GetTypeInfo().Assembly.DefinedTypes.Where(t =>
                typeof(IRepository).GetTypeInfo().IsAssignableFrom(t.AsType()) && t.IsClass)
            .Select(p => p.AsType());

        foreach (var r in repos)
            if (r.Name != "Repository")
                service.AddScoped(r.GetInterface($"I{r.Name}") ?? throw new InvalidOperationException(), r);

        return service;
    }
}