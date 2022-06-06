using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using NLog.Web;
using Vulder.Admin.Application;
using Vulder.Admin.Core.Validators;
using Vulder.Admin.Infrastructure;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Middlewares;

AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDefaultCorsPolicy();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultJwtConfiguration(builder.Configuration);
builder.Services.AddMvc()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthModelValidator>());

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuild =>
{
    containerBuild.RegisterModule(new ApplicationModule(builder.Configuration));
    containerBuild.RegisterModule(new InfrastructureModule(builder.Configuration["PostgresConnectionString"]));
}));
builder.Host.UseNLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<ControllerActionLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CORS");

app.Run();

public partial class Program
{
}