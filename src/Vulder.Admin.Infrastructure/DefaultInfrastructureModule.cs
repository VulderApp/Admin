using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.School;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Data;
using Vulder.Admin.Infrastructure.Data.Interfaces;
using Vulder.Admin.Infrastructure.Data.Repositories;
using Vulder.Admin.Infrastructure.Handlers.User;
using Module = Autofac.Module;

namespace Vulder.Admin.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();
        private readonly string _postgresConnectionString;

        public DefaultInfrastructureModule(string postgresConnectionString)
        {
            _postgresConnectionString = postgresConnectionString;
            _assemblies.Add(Assembly.GetAssembly(typeof(School)));
            _assemblies.Add(Assembly.GetAssembly(typeof(User)));
            _assemblies.Add(Assembly.GetAssembly(typeof(NewUserRequestHandler)));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
                .As(typeof(IUserRepository))
                .InstancePerLifetimeScope();

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AppDbContext>()
                .WithParameter("postgresConnectionString", _postgresConnectionString)
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
