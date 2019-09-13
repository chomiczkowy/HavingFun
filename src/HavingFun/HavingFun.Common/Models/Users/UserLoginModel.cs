using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace HavingFun.Common.Models
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password{ get; set; }
    }
}
