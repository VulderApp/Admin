using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Vulder.Admin.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers.Auth;

[Collection("Controllers collection")]
public class AuthControllerTest
{
    private readonly AdminCredentialsFixture _adminCredentials;

    public AuthControllerTest(AdminCredentialsFixture adminCredentials)
    {
        _adminCredentials = adminCredentials;
    }

    [Fact]
    public async void POST_1_RegisterController_200_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = _adminCredentials.Email,
            Password =
                _adminCredentials.Password
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/register", httpContent);
        var registerUserModel = JsonConvert.DeserializeObject<AuthUserDto>(await response.Content.ReadAsStringAsync());

        _adminCredentials.Token = registerUserModel?.Token;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(registerUserModel?.Token);
    }

    [Fact]
    public async void POST_2_RegisterController_500_StatusCode()
    {
        var body = new RegisterUserModel
        {
            Email = _adminCredentials.Email,
            Password =
                "dg==XE=cEoiOUA2P1IxTWUjcX5XeSQsOz1kJE9+K01leUg=UmR2aKX5Ge1txUj1yQVNdZTdsKUt7IWBNVXlsYUYtRmozQjg/eSEg"
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/register", httpContent);

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async void POST_3_LoginController_200_StatusCode()
    {
        var body = new LoginUserModel
        {
            Email = _adminCredentials.Email,
            Password =
                _adminCredentials.Password
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();

        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/auth/login", httpContent);
        var registerUserModel = JsonConvert.DeserializeObject<AuthUserDto>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(registerUserModel?.Token);
    }
}