﻿using HavingFun.EFDA.Context;
using HavingFun.EFDAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HavingFun.EFDAL
{
    public class CommandRepositoriesContainer
    {
        public UserCommandRepository UserCommandRepository { get; set; }
        public UserQueryRepository UserQueryRepository { get; set; }

        public CommandRepositoriesContainer(DbContextOptions<MainDBContext> dbContextOptions)
        {
            var dbContext = new MainDBContext(dbContextOptions);

            UserCommandRepository = new UserCommandRepository(dbContext);
            UserQueryRepository = new UserQueryRepository(dbContext);
        }
    }
}
