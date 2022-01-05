using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Vulder.Admin.Core.Models;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers.Auth;

public class RegisterControllerTest
{
    [Fact]
    public async void POST_RegisterController_200_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = "example@example.com",
            Password = "nevergiveup"
        };
        
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/Register", httpContent);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}