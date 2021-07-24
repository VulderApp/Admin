using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Core.Services;
using Module = Autofac.Module;

namespace Vulder.Admin.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHashService>()
                .As<IPasswordHashService>().InstancePerLifetimeScope();
        }
    }
}
