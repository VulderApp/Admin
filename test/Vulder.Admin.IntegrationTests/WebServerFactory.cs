using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Vulder.Admin.IntegrationTests;

public class WebServerFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("REGISTER_ONLY_ONE_ACCOUNT", "true");
        
        builder.UseEnvironment("Production");
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .AddEnvironmentVariables();
        });
    }
}