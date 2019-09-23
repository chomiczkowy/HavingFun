using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table(nameof(ProductAttachment), Schema = "schProducts")]
    public class ProductAttachment
    {
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product{ get; set; }

        [Required]
        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
