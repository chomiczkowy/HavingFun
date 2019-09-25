using HavingFun.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.BLL
{
    public interface IUserService
    {
        UserModel Authenticate(Command<UserLoginModel> cmd);
        PageableQueryResult<UserModel> GetPage(Query<PageableQuery> query);
        int? Create(Command<EditUserModel> userModel);
        UserModel GetById(Query<int> query);
        object Update(Command<EditUserModel> cmd);
        UserModel GetByName(Query<string> query);
    }
}
