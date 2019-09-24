using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavingFun.Common.Models.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace HavingFun.API.Shop.Controllers
{
    [Route("api/productCategories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        [HttpGet("tree")]
        public ProductCategoryTreeItem[] GetAllForTree()
        {
            return new ProductCategoryTreeItem[]
            {
                new ProductCategoryTreeItem(){Data=1, Label="Kategoria 1"},
                new ProductCategoryTreeItem()
                {
                    Data=2,
                    Label="Kategoria 2",
                    Children=new ProductCategoryTreeItem[]
                    {
                        new ProductCategoryTreeItem(){
                            Data=3,
                            Label="Kategoria 2_1"
                        },
                        new ProductCategoryTreeItem(){
                            Data=4,
                            Label="Kategoria 2_2"
                        },
                        new ProductCategoryTreeItem(){
                            Data=5,
                            Label="Kategoria 2_3",
                            Children=new ProductCategoryTreeItem[]
                            {
                                 new ProductCategoryTreeItem(){
                                    Data=6,
                                    Label="Kategoria 2_3_1"
                                },
                                new ProductCategoryTreeItem(){
                                    Data=7,
                                    Label="Kategoria 2_3_2"
                                }
                            }
                        },
                    }
                }
            };
        }
    }
}
