using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Dashboard;
using HavingFun.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;

namespace HavingFun.Apps.JobScheduler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            services.AddHangfire(x =>
                x.UseSqlServerStorage(connectionStrings.HangfireDb)
                 .UseNLogLogProvider());

            services.AddHangfireServer();

            var logFactory = NLogBuilder.ConfigureNLog("nlog.config");

            services.AddTransient(sp => logFactory.GetCurrentClassLogger());
            services.AddTransient<LoggerHelper, LoggerHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireDashboard(options: new DashboardOptions()
            {
                Authorization = new[] { new LocalRequestsOnlyAuthorizationFilter() }
            });

            new JobRegistrator(app.ApplicationServices.GetService<LoggerHelper>())
                .RegisterJobs();
        }
    }

    public class ConnectionStrings
    {
        public string HangfireDb{ get; set; }
    }
}
