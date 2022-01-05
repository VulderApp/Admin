using Autofac;
using Vulder.Admin.Infrastructure.Database.Interfaces;
using Vulder.Admin.Infrastructure.Database.Repositories;
using Module = Autofac.Module;

namespace Vulder.Admin.Infrastructure.Database;

public class DatabaseModule : Module
{
    private readonly string _connectionString;

    public DatabaseModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AppDbContext>()
            .WithParameter("connectionString", _connectionString)
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<UserRepository>()
            .As<IUserRepository>()
            .InstancePerLifetimeScope();
    }
}