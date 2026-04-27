using GUPBlazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

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
