using HavingFun.Common.DDD;
using HavingFun.EFDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.EFDAL.AggregateRoots
{
    public class UserAggregateRoot : AggregateRoot<User>
    {
        public UserAggregateRoot(User user) : base(user) { }
    }
}
