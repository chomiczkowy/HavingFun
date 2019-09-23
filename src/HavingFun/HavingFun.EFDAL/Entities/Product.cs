using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table(nameof(Product), Schema = "schProducts")]
    public class Product
    {
        public Product()
        {
            Photos = new HashSet<ProductAttachment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(1024)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategory Category { get; set; }

        public int ThumbnailId { get; set; }

        [ForeignKey(nameof(ThumbnailId))]
        public virtual Attachment Thumbnail { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<ProductAttachment> Photos {get;set;}
    }
}
