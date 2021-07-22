using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Module = Autofac.Module;

namespace Vulder.Admin.Core
{
    class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
