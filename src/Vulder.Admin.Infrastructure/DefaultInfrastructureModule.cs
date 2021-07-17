using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Vulder.Admin.Infrastructure.Data;
using Vulder.SharedKernel.Interface;
using Module = Autofac.Module;

namespace Vulder.Admin.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                return t => context.Resolve<IComponentContext>().Resolve(t);
            });

            var mediatROpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatROpenType in mediatROpenTypes)
            {
                builder.RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatROpenType)
                    .AsImplementedInterfaces();
            }

        }
    }
}
