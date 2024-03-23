using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addProduct")]
     //   [Authorize(Roles = "random")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("updateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.Update(product);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("deleteProduct")]

        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getAllProduct")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductByProductName")]
        public IActionResult GetListProductByProductName(string getListProductByProductName)
        {
            var result = _productService.GetListByProductName(getListProductByProductName);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductByQuantityPerUnit")]
        public IActionResult GetListByQuantityPerUnit(int quantityPerUnit)
        {
            var result = _productService.GetListByQuantityPerUnit(quantityPerUnit);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductByUnitsInStock")]
        public IActionResult GetListProductByUnitsInStock(int unitsInStock)
        {
            var result = _productService.GetListByUnitsInStock(unitsInStock);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductByPriceRange")]
        public IActionResult GetListProductByPriceRange(int price1, int price2)
        {
            var result = _productService.GetListByPriceRange(price1, price2);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductByUnitsOnOrder")]
        public IActionResult GetListProductByUnitsOnOrder(int unitsOnOrder)
        {
            var result = _productService.GetListByUnitsOnOrder(unitsOnOrder);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListByCategoryId")]
        public IActionResult GetListProductByCategoryId(int categoryId)
        {
            var result = _productService.GetListByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
