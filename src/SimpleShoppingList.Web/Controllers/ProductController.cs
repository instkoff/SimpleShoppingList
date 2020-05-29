using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleShoppingList.Domain.Abstractions;
using SimpleShoppingList.Domain.Models;

namespace SimpleShoppingList.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] ProductModel productModel)
        {
            var result = await _productService.Create(productModel);
            return Ok(result);
        }

        [HttpGet("get-all-products")]
        public ActionResult<List<ProductModel>> GetAllProducts()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }
        [HttpGet("get-product")]
        public ActionResult<ProductModel> GetConcreteProduct(Guid id)
        {
            var result = _productService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateProduct([FromBody] ProductModel productModel)
        {
            var result = await _productService.Update(productModel);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}