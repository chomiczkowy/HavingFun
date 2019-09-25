using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Models.Products
{
    public class ProductListSearchQuery:PageableQuery
    {
        public int[] CategoriesIds { get; set; }
    }
}
