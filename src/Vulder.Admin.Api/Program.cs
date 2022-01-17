using Autofac;
using Autofac.Extensions.DependencyInjection;
using Vulder.Admin.Application;
using Vulder.Admin.Infrastructure;
using Vulder.Admin.Infrastructure.Middlewares;
using Vulder.SharedKernel;

AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidators();
builder.Services.AddDefaultCorsPolicy();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultJwtConfiguration(builder.Configuration);

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

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CORS");

app.Run();

public partial class Program { }
