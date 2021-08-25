using Autofac;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Core.Services;
using Module = Autofac.Module;

namespace Vulder.Admin.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtGenerationService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();
        }
    }
}