using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Vulder.Admin.Application.Auth.Jwt;
using Vulder.Admin.Application.Auth.Login;
using Vulder.Admin.Application.Auth.Register;
using Vulder.Admin.Core.Configuration;
using Module = Autofac.Module;

namespace Vulder.Admin.Application;

public class ApplicationModule : Module
{
    private readonly List<Assembly?> _assemblies = new();
    private readonly IConfiguration _configuration;

    public ApplicationModule(IConfiguration configuration)
    {
        _configuration = configuration;

        _assemblies.Add(Assembly.GetAssembly(typeof(RegisterUserRequestHandler)));
        _assemblies.Add(Assembly.GetAssembly(typeof(LoginUserRequestHandler)));
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(new JwtConfiguration
        {
            Key = _configuration["Jwt:Key"],
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
        })
            .As<IJwtConfiguration>()
            .SingleInstance();

        builder.RegisterType<JwtGenerationService>()
            .As<IJwtGenerationService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        builder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });

        var mediatorOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestExceptionHandler<,,>),
            typeof(IRequestExceptionHandler<,>),
            typeof(INotificationHandler<>)
        };

        foreach (var mediatorOpenType in mediatorOpenTypes)
            builder.RegisterAssemblyTypes(_assemblies.ToArray()!)
                .AsClosedTypesOf(mediatorOpenType)
                .AsImplementedInterfaces();
    }
}