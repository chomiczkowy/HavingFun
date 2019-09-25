using System;
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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private LoggerHelper _logger;
        private IProductService _productService;

        public ProductController(IProductService productService, 
                                LoggerHelper logger)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET api/values
        [HttpGet("{productId}")]
        public ActionResult<ProductRichModel> Get(int productId)
        {
            _logger.Info($"Getting product by id: {productId}");

            var product = _productService.GetProductRichModel(productId);
            return product;
        }
    }
}
