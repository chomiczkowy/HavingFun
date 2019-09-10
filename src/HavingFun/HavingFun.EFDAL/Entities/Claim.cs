using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table("Claims", Schema = "schUsers")]
    public class Claim
    {
        public Claim()
        {
            UserClaims = new HashSet<UserClaims>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Type { get; set; }

        [Required]
        [StringLength(1024)]
        public string Value { get; set; }

        public ICollection<UserClaims> UserClaims { get; set; }
    }
}
