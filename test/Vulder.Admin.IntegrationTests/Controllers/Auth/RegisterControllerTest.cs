using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Vulder.Admin.Core.Models;
using Xunit;
using ExceptionModel = Vulder.SharedKernel.Models.ExceptionModel;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Vulder.Admin.IntegrationTests.Controllers.Auth;

[Collection("Register Collection")]
public class RegisterControllerTest
{
    [Fact]
    public async void POST_RegisterController_200_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = "example@example.com",
            Password = "dg==OXcEoiOUA2P1IxTWUjcX5XeSQsOz1kJE9+K01leUUmR2TEFaKX5Ge1txUj1yQVNdZTdsKUt7IWBNVXlsYUYtRmozQjg/eSEg"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/Register", httpContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void POST_RegisterController_500_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = "example@example.com",
            Password = "dg==XE=cEoiOUA2P1IxTWUjcX5XeSQsOz1kJE9+K01leUg=UmR2TEFaKX5Ge1txUj1yQVNdZTdsKUt7IWBNVXlsYUYtRmozQjg/eSEg"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/Register", httpContent);

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}