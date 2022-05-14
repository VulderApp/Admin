using Autofac;
using Vulder.Admin.Infrastructure.Database;

namespace Vulder.Admin.Infrastructure;

public class InfrastructureModule : Module
{
    private readonly string _connectionString;

    public InfrastructureModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new DatabaseModule(_connectionString));
    }
}