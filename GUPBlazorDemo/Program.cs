using GUPBlazorDemo.Components;
using GUPBlazorDemo.Services;
using Microsoft.AspNetCore.DataProtection;

namespace GUPBlazorDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddGUPBlazor();
            builder.Services.AddScoped<DemoDirectionService>();
            builder.Services.AddSingleton<DesignTokenCatalogue>();
            builder.Services.AddSingleton<ExampleSourceProvider>();

            // Persist the key ring so antiforgery cookies survive a container restart.
            var keyRing = builder.Configuration["DataProtection:KeyRingPath"];
            if (!string.IsNullOrWhiteSpace(keyRing))
            {
                builder.Services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(keyRing));
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
