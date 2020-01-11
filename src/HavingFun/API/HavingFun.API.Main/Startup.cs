﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HavingFun.API.Common;
using HavingFun.API.Main.Configuration;
using HavingFun.Common;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Messages;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;
using MassTransit;

namespace HavingFun.API.Main
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // configure strongly typed settings objects
            var customAppSettingsSection = Configuration.GetSection("CustomSettings").Get<MainApiSettings>();
            services.AddSingleton(customAppSettingsSection);
            var connectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            // configure jwt authentication
            SetUpJWT(services, customAppSettingsSection);
            SetUpSwagger(services);
            SetUpApiVersioning(services);
            SetUpRabbitMq(services, customAppSettingsSection);

            IdentityModelEventSource.ShowPII = true;

            return ConfigureDI(services, connectionStrings);
        }

        private static void SetUpApiVersioning(IServiceCollection services)
        {
            // Versioning setup
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        private static void SetUpJWT(IServiceCollection services, MainApiSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.JWTSecret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private static void SetUpSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API .NET Core Main API",
                    Description = "Przykładowy opis",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Strona główna - Karol Łątka",
                    }
                });
                c.DescribeAllEnumsAsStrings();
            });
        }

        private static void SetUpRabbitMq(IServiceCollection services, MainApiSettings appSettings)
        {
            var rabbitServerUri = new Uri(appSettings.RabbitMq.HostUrl);

            services.AddMassTransit((cfg) =>
            {
                cfg.AddBus(isp =>
                {
                    var bus= Bus.Factory.CreateUsingRabbitMq(busCfg =>
                    {
                        busCfg.Host(new Uri(appSettings.RabbitMq.HostUrl), host =>
                        {
                            host.Username(appSettings.RabbitMq.Username);
                            host.Password(appSettings.RabbitMq.Password);
                        });

                        //busCfg.Message<UserCreatedMessage>(x =>
                        //{

                        //});                    
                    });

                    bus.Start();
                    return bus;
                });
            });
        }

        private static IServiceProvider ConfigureDI(IServiceCollection services, ConnectionStrings connectionStrings)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Properties["ConnectionStrings"] = connectionStrings;
            containerBuilder.RegisterModule<MainApiDIModule>();
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.ConfigureExceptionHandler(app.ApplicationServices.GetService<LoggerHelper>());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
