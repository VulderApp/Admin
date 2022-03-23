using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Vulder.Admin.Core.Models;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers.Auth;

public class AuthControllerTest
{
    [Fact]
    public async void POST_1_RegisterController_200_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = "example@example.com",
            Password =
                "dg==OXcEoiOUA2P1IxTWUjcX5XeSQsOz1kJE9+K01leUUmR2TEFaKX5Ge1txUj1yQVNdZTdsKUt7IWBNVXlsYUYtRmozQjg/eSEg"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/Register", httpContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void POST_2_RegisterController_500_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = "example@example.com",
            Password =
                "dg==XE=cEoiOUA2P1IxTWUjcX5XeSQsOz1kJE9+K01leUg=UmR2TEFaKX5Ge1txUj1yQVNdZTdsKUt7IWBNVXlsYUYtRmozQjg/eSEg"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/Register", httpContent);

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
    
    [Fact]
    public async void POST_3_LoginController_200_StatusCode()
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