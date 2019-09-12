using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.BLL
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
