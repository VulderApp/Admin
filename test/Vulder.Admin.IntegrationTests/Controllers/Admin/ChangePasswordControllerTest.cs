using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Vulder.Admin.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers.Admin;

[Collection("Controllers collection")]
public class ChangePasswordControllerTest
{
    private readonly AdminCredentialsFixture _adminCredentials;

    public ChangePasswordControllerTest(AdminCredentialsFixture adminCredentials)
    {
        _adminCredentials = adminCredentials;
    }

    [Fact]
    public async void POST_RegisterController_200_StatusCode()
    {
        var changePasswordModel = new ChangePasswordModel
        {
            CurrentPassword = _adminCredentials.Password,
            NewPassword = "NzjDED/7tqsSFI62KRwHyBe8eHOFjGbyiDw/M1BEOEw="
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(changePasswordModel), Encoding.UTF8,
            "application/json");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_adminCredentials.Token}");
        using var response = await client.PutAsync("/admin/ChangePassword", httpContent);
        var registerUserModel = JsonConvert.DeserializeObject<ResultDto>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.True(registerUserModel?.Result);
    }
}