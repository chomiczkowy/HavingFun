using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HavingFun.API.Main
{
    public class MainApiSettings
    {
        public string MySetting { get; set; }
        public string JWTSecret { get; set; }

        public RabbitMqConfig RabbitMq { get; set; }
    }

    public class RabbitMqConfig
    {
        public string HostUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
