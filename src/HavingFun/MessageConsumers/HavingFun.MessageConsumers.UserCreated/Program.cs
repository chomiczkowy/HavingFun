using HavingFun.API.Main.MessageConsumers;
using System;
using Topshelf;

namespace HavingFun.MessageConsumers.UserCreated
{
    class Program
    {
        public static int Main()
        {
            return (int)HostFactory.Run(cfg => cfg.Service(x => new EventConsumerService()));
        }
    }
}
