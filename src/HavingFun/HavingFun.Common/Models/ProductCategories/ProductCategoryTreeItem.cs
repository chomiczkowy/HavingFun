using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Models.ProductCategories
{
    public class ProductCategoryTreeItem
    {
        public string Label { get; set; }
        public int Data { get; set; }
        public ProductCategoryTreeItem[] Children { get; set; }
    }
}
