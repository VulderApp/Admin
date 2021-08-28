using Autofac;
using Microsoft.Extensions.Configuration;
using Vulder.Admin.Core.Configuration;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Core.Services;
using Module = Autofac.Module;

namespace Vulder.Admin.Core
{
    public class DefaultCoreModule : Module
    {
        private readonly IConfiguration _configuration;
        
        public DefaultCoreModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();

            builder.RegisterInstance(new AuthConfiguration
                {
                    Key = _configuration["Auth:Key"],
                    Issuer = _configuration["Auth:Issuer"]
                })
                .As<IAuthConfiguration>();
        }
    }
}