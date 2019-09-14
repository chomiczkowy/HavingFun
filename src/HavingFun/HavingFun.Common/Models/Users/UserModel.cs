using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace HavingFun.Common.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Claims = new Claim[0];
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}
