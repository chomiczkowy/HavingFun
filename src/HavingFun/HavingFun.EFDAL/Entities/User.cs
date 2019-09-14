using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table("Users", Schema = "schUsers")]
    public class User
    {
        public User()
        {
            UserClaims = new HashSet<UserClaims>();
            UserRoles = new HashSet<UserRoles>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        [Required]
        [StringLength(256)]
        public string EmailAddress { get; set; }

        [Required]
        public bool IsActivated { get; set; }

        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserClaims> UserClaims { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
