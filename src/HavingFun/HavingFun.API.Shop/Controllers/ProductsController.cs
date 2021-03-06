﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavingFun.Common;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.Common.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HavingFun.API.Shop.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private LoggerHelper _logger;
        private IProductService _productService;

        public ProductsController(IProductService productService,
                                  LoggerHelper logger)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<PageableQueryResult<ProductQueryItem>> Get([FromQuery]ProductListSearchQuery query)
        {
            _logger.Info($"Getting product list with query: {Environment.NewLine}{JsonConvert.SerializeObject(query, Formatting.Indented)}");
            return _productService.GetByQuery(query);
        }
    }
}
