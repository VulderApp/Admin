using System;
using System.Collections;
using System.Collections.Generic;
using Autofac;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Vulder.Admin.Core;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;
using Vulder.Admin.Infrastructure;

namespace Vulder.Admin.Api
{
    public class Startup
    {
        private const string CorsPolicyName = "Admin";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtDefault(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyName,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000/")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation();
            services.AddModelsToValidate();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vulder.Admin.Api", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Auth header",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new [] { "Bearer" } }   
                });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DefaultInfrastructureModule(
               Environment.GetEnvironmentVariable("POSTGRES_CONNECTION")
               ?? Configuration["Postgres:ConnectionString"])
            );
            builder.RegisterModule(new DefaultCoreModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vulder.Admin.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicyName);
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
