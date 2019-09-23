using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table(nameof(Attachment), Schema = "schProducts")]
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(256)]
        [Required]
        public string FileName { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public string Description { get; set; }
    }
}
