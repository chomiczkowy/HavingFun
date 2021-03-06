﻿using HavingFun.Common.ConfigurationsSections;
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
}
