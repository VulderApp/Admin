using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Vulder.Admin.Core.Models;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers.Auth;

public class LoginControllerTest
{
    [Fact]
    public async void POST_RegisterController_200_StatusCode()
    {
        var registerModel = new RegisterUserModel
        {
            Email = "login@example.com",
            Password = "nevergiveup"
        };
        
        var loginModel = new LoginUserModel
        {
            Email = registerModel.Email,
            Password = registerModel.Password
        };
        
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(registerModel), Encoding.UTF8, "application/json");
        await client.PostAsync("/auth/Register", httpContent);
        
        httpContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/Login", httpContent);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}