using Autofac;
using HavingFun.API.Common;
using HavingFun.DapperDAL;
using HavingFun.DapperDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.BLL
{
    public class DapperDALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionStrings = builder.Properties["ConnectionStrings"] as ConnectionStrings;

            builder.RegisterType<QueryRepositoriesContainer>().AsSelf().WithParameter("connectionString", connectionStrings.MainDb);
        }
    }
}
