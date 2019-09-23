using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HavingFun.EFDAL.Entities
{
    [Table(nameof(ProductCategory), Schema = "schProducts")]
    public class ProductCategory
    {
        public ProductCategory()
        {
            ChildCategories = new HashSet<ProductCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(256)]
        public string Name { get; set; }

        public int ParentCategoryId { get; set; }

        public ProductCategory ParentCategory { get; set; }

        public virtual ICollection<ProductCategory> ChildCategories { get; set; }
    }
}
