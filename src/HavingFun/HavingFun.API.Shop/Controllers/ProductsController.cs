using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavingFun.Common.Models;
using HavingFun.Common.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace HavingFun.API.Shop.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<PageableQueryResult<ProductQueryItem>> Get(ProductListSearchQuery query)
        {
            const int itemsPerCategory = 10;
            string[] words = new[] { "Office thing", "SSD Hard drive", "GPU Nvidia", "Intel CPU", "AMD CPU" };
            var items = new List<ProductQueryItem>();

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

            var categoriesIds = query.CategoriesIds;
            var allItemsFiltered = items.Where(x => categoriesIds.Contains(x.Id / 1000)).ToArray();
            var resultItems = allItemsFiltered.Skip(query.PageNumber * query.PageSize).Take(query.PageSize).ToArray();

            return new PageableQueryResult<ProductQueryItem>()
            {
                AllItemsCount = allItemsFiltered.Length,
                Items = resultItems
            };
        }
    }
}
