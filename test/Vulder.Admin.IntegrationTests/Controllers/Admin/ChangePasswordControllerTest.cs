using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers.Admin;

public class ChangePasswordControllerTest
{
    [Fact]
    public async void POST_RegisterController_200_StatusCode()
    {
        var registerModel = new RegisterUserModel
        {
            Email = "change@example.com",
            Password = "XSfsT1bvbPHLwCcaPYq/Waum5I8EUSZ1aTLy1bo/Gz0="
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");
        using var registerResponse = await client.PostAsync("/auth/Register", httpContent);
        var token = JsonConvert.DeserializeObject<AuthUserDto>(await registerResponse.Content.ReadAsStringAsync())!.Token;

        var changePasswordModel = new ChangePasswordModel
        {
            CurrentPassword = "XSfsT1bvbPHLwCcaPYq/Waum5I8EUSZ1aTLy1bo/Gz0=",
            NewPassword = "NzjDED/7tqsSFI62KRwHyBe8eHOFjGbyiDw/M1BEOEw="
        };

        httpContent = new StringContent(JsonConvert.SerializeObject(changePasswordModel), Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        using var changePasswordResponse = await client.PutAsync("/admin/ChangePassword", httpContent);

        Assert.Equal(HttpStatusCode.OK, changePasswordResponse.StatusCode);
    }
}