using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table(nameof(UserRoles), Schema = "schUsers")]
    public class UserRoles
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
