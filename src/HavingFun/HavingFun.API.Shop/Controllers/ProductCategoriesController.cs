﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavingFun.Common;
using HavingFun.Common.Models.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace HavingFun.API.Shop.Controllers
{
    [Route("api/productCategories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private LoggerHelper _logger;

        public ProductCategoriesController(LoggerHelper logger)
        {
            _logger = logger;
        }

        [HttpGet("tree")]
        public ProductCategoryTreeItem[] GetAllForTree()
        {
            _logger.Info("Getting product categories tree");
            return new ProductCategoryTreeItem[]
            {
                new ProductCategoryTreeItem(){Data=1, Label="Office stuff"},
                new ProductCategoryTreeItem()
                {
                    Data=200,
                    Label="Computer parts",
                    Children=new ProductCategoryTreeItem[]
                    {
                        new ProductCategoryTreeItem(){
                            Data=2,
                            Label="Hard drives"
                        },
                        new ProductCategoryTreeItem(){
                            Data=3,
                            Label="Graphic cards"
                        },
                        new ProductCategoryTreeItem(){
                            Data=400,
                            Label="CPU",
                            Children=new ProductCategoryTreeItem[]
                            {
                                 new ProductCategoryTreeItem(){
                                    Data=4,
                                    Label="Intel"
                                },
                                new ProductCategoryTreeItem(){
                                    Data=5,
                                    Label="AMD"
                                }
                            }
                        },
                    }
                }
            };
        }
    }
}
