using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Infrastructure.Configurations
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}