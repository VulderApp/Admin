namespace Vulder.Admin.IntegrationTests.Fixtures;

public class AdminCredentialsFixture
{
    public string? Token { get; set; }
    public string Email { get; } = "example@example.com";

    public string Password { get; } =
        "dg==OXcEoiOUA2P1IxTWUjcX5XeSQsOz1kJE9+K01leUUmR2TEFaKX5Ge1txUj1yQVNdZTdsKUt7IWBNVXlsYUYtRmozQjg/eSEg";
}