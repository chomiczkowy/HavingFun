using HavingFun.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.BLL
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        PageableQueryResult<UserModel> GetPage(int pageSize, int pageNumber);
        int? Create(EditUserModel userModel);
        UserModel GetById(int id);
    }
}
