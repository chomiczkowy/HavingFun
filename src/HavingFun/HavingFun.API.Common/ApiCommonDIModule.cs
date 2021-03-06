﻿using Autofac;
using HavingFun.Common.Helpers;
using HavingFun.Common.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.API.Common
{
    public class ApiCommonDIModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JWTTokenProvider>().As<ITokenProvider>();
            builder.RegisterType<SHA256PasswordHasher>().As<IPasswordHasher>();
        }
    }
}
