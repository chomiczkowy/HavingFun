﻿using Autofac;
using HavingFun.EFDAL.Context;
using HavingFun.EFDAL;
using HavingFun.EFDAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.BLL
{
    public class EFDALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandRepositoriesContainer>().AsSelf();
        }
    }
}
