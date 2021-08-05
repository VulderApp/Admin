using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Vulder.Admin.Core.ProjectAggregate.School;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Data;
using Vulder.Admin.Infrastructure.Handlers.User;
using Vulder.SharedKernel.Interface;
using Module = Autofac.Module;

namespace Vulder.Admin.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();

        public DefaultInfrastructureModule()
        {
            _assemblies.Add(Assembly.GetAssembly(typeof(School)));
            _assemblies.Add(Assembly.GetAssembly(typeof(User)));
            _assemblies.Add(Assembly.GetAssembly(typeof(StartupSetup)));
            _assemblies.Add(Assembly.GetAssembly(typeof(NewUserRequestHandler)));
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            var mediatROpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionHandler<,>),
                typeof(INotificationHandler<>),
                typeof(IRequest<>)
            };

            foreach (var mediatROpenType in mediatROpenTypes)
            {
                builder.RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatROpenType)
                    .AsImplementedInterfaces();
            }
            
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}
