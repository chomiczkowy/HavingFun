using HavingFun.Common.Models;
using HavingFun.Common.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Interfaces.BLL
{
    public interface IProductService
    {
        PageableQueryResult<ProductQueryItem> GetByQuery(ProductListSearchQuery query);
        ProductRichModel GetProductRichModel(int productId);
    }
}
