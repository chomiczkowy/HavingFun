using HavingFun.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.BLL
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        PageableQueryResult<User> GetAll(int pageSize, int pageNumber);
    }
}
