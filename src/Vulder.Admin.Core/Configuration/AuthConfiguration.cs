using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Core.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}