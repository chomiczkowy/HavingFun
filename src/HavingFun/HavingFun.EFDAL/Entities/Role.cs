using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table("Roles", Schema = "schUsers")]
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }


        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
