﻿using Autofac;
using HavingFun.API.Common;
using HavingFun.BLL;
using HavingFun.Common;
using HavingFun.Common.Interfaces.BLL;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HavingFun.API.Main.Configuration
{
    public class MainApiDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();

            var logFactory = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config");

            builder.Register(c => logFactory.GetCurrentClassLogger()).As<Logger>();
            builder.RegisterType<LoggerHelper>().AsSelf();

            builder.RegisterModule<BLLModule>();
            builder.RegisterModule<ApiCommonDIModule>();
        }
    }
}
