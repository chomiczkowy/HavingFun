using HavingFun.Common;
using HavingFun.Common.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HavingFun.API.Main.MessageConsumers
{
    public class UserCreatedConsumer : IConsumer<UserCreatedMessage>
    {
        private LoggerHelper _logger;

        public UserCreatedConsumer(LoggerHelper logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<UserCreatedMessage> context)
        {
            _logger.Info($"UserCreatedMessage consume start UserId: {context.Message.UserId}");

            return Task.Delay(100).ContinueWith((t) => 
            { 
                _logger.Info($"UserCreatedMessage consume end UserId: {context.Message.UserId}"); 
            });
        }
    }
}
