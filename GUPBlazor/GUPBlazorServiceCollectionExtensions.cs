using GUPBlazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Registration helpers for the GUPBlazor component library.</summary>
public static class GUPBlazorServiceCollectionExtensions
{
    /// <summary>
    /// Registers all GUPBlazor services. Call once from Program.cs.
    /// </summary>
    public static IServiceCollection AddGUPBlazor(this IServiceCollection services)
    {
        services.AddScoped<ToastService>();
        return services;
    }
}
