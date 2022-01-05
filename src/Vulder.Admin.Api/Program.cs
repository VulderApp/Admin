using Autofac;
using Autofac.Extensions.DependencyInjection;
using Vulder.Admin.Application;
using Vulder.Admin.Infrastructure;

AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidators();
builder.Services.AddDefaultJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuild =>
{
    containerBuild.RegisterModule(new ApplicationModule(builder.Configuration));
    containerBuild.RegisterModule(new InfrastructureModule(builder.Configuration["PostgresConnectionString"]));
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();

public partial class Program { }
