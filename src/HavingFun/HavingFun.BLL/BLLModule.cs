using Autofac;
using HavingFun.API.Common;
using HavingFun.EFDA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.BLL
{
    public class BLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionStrings = builder.Properties["ConnectionStrings"] as ConnectionStrings;
            var optionsBuilder = new DbContextOptionsBuilder<MainDBContext>();
            optionsBuilder.UseNpgsql(connectionStrings.MainDb);

            builder.Register((componentContext) => optionsBuilder.Options);
            builder.RegisterModule<EFDALModule>();
        }
    }
}
