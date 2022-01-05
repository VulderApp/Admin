using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Vulder.Admin.IntegrationTests;

public class WebServerFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Production");
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .AddEnvironmentVariables();
        });
    }
}