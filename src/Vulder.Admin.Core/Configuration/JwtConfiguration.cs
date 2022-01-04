using System.Diagnostics.CodeAnalysis;

namespace Vulder.Admin.Core.Configuration;

public class JwtConfiguration : IJwtConfiguration
{
    public string? Key { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
}