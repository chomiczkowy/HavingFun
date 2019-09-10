using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table(nameof(UserClaims), Schema = "schUsers")]
    public class UserClaims
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ClaimId { get; set; }
        public virtual Claim Claim{ get; set; }
    }
}
