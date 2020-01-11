using HavingFun.API.Main.MessageConsumers;
using HavingFun.Common.ConfigurationsSections;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Topshelf;

namespace HavingFun.MessageConsumers.UserCreated
{
    class EventConsumerService : ServiceControl
    {
        IBusControl _bus;

        public bool Start(HostControl hostControl)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            _bus = ConfigureBus(configuration);
            _bus.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _bus?.Stop(TimeSpan.FromSeconds(30));

            return true;
        }

        IBusControl ConfigureBus(IConfigurationRoot configuration)
        {
            var logFactory = new NLog.LogFactory();
            logFactory.LoadConfiguration("nlog.config");

            RabbitMqConfig configFromfile = configuration.GetSection("RabbitMq").Get<RabbitMqConfig>();

            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(configFromfile.HostUrl, (hostCfg)=>
                {
                    hostCfg.Username(configFromfile.Username);
                    hostCfg.Password(configFromfile.Password);
                });

                cfg.ReceiveEndpoint("user_created", e =>
                {
                    e.Consumer<UserCreatedConsumer>(() =>
                    {
                        return new UserCreatedConsumer(new Common.LoggerHelper(logFactory.GetLogger("UserCreatedConsumer")));
                    });
                });
            });
        }
    }
}
