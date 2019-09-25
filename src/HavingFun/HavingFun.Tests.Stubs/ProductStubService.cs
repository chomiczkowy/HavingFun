using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.Common.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HavingFun.Tests.Stubs
{
    public class ProductStubService : IProductService
    {
        private List<ProductQueryItem> items = new List<ProductQueryItem>();

        public ProductStubService()
        {
            const int itemsPerCategory = 10;
            string[] words = new[] { "Office thing", "SSD Hard drive", "GPU Nvidia", "Intel CPU", "AMD CPU" };

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < itemsPerCategory; j++)
                {
                    items.Add(new ProductQueryItem()
                    {
                        Id = i * 1000 + j,
                        Name = $"{words[i - 1]} {j + 1}",
                        Description = $"{words[i - 1]} - the very best in the world {j + 1}"
                    });
                }
            }
        }

        public PageableQueryResult<ProductQueryItem> GetByQuery(ProductListSearchQuery query)
        {
            var categoriesIds = query.CategoriesIds;
            var allItemsFiltered = (categoriesIds != null && categoriesIds.Any() ? items.Where(x => categoriesIds.Contains(x.Id / 1000)) : items).ToArray();
            var resultItems = allItemsFiltered.Skip(query.PageNumber * query.PageSize).Take(query.PageSize).ToArray();

            return new PageableQueryResult<ProductQueryItem>()
            {
                AllItemsCount = allItemsFiltered.Length,
                Items = resultItems
            };
        }

        public ProductRichModel GetProductRichModel(int productId)
        {
            var item = items.First(x => x.Id == productId);
            return new ProductRichModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
        }
    }
}
