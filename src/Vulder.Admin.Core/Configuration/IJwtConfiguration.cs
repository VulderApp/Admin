namespace Vulder.Admin.Core.Configuration;

public interface IJwtConfiguration
{
    string Key { get; set; }
    string Issuer { get; set; }
    string Audience { get; set; }
}