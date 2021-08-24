using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Infrastructure.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public string Key { get; set; }
    }
}