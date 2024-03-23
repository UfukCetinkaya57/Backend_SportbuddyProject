using BusinessLayer.Abstract;
using CoreLayer.Entities.Concerete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportBuddyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        public ProductCategoriesController(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }
        [HttpGet("getAllProductCategories")]
        public IActionResult GetListProductCategory()
        {
            var result = _productCategoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductCategoryByName")]
        public IActionResult GetListProductCategoryByName(string Name)
        {
            var result = _productCategoryService.GetListByName(Name);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getListProductCategoryByCategoryType")]
        public IActionResult GetListProductCategoryByCategoryType(string Type)
        {
            var result = _productCategoryService.GetListByCategoryType(Type);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getProductCategoryById")]

        public IActionResult GetProductCategoryById(int Id)
        {
            var result = _productCategoryService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addProductCategory")]

        public IActionResult AddProductCategory(ProductCategory ProductCategory)
        {
            var result = _productCategoryService.Add(ProductCategory);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateProductCategory")]
        [Authorize(Roles = "random")]

        public IActionResult UpdateProductCategory(ProductCategory ProductCategory)
        {
            var result = _productCategoryService.Update(ProductCategory);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteProductCategory")]
        public IActionResult DeleteProductCategory(int id)
        {
            var result = _productCategoryService.Delete(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
