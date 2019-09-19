using Autofac;
using HavingFun.API.Common;
using HavingFun.EFDAL.Context;
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
            optionsBuilder.UseSqlServer(connectionStrings.MainDb);

            builder.Register((componentContext) => optionsBuilder.Options);
            builder.RegisterModule<EFDALModule>();
            builder.RegisterModule<DapperDALModule>();
        }
    }
}
