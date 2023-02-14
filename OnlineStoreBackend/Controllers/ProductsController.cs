using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ProductsManagement;

namespace OnlineStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IUnitOfWork unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = unitOfWork.ProductRepository.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = unitOfWork.ProductRepository.Get(id);
            if(product == null) return NotFound();
            return Ok(product);
        }
       
        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProductRepository.Create(product);
                unitOfWork.Complete();
                return Created("Product Created Succesfully", product);
            }
            return BadRequest();

        }
        [HttpPut] 
        public IActionResult Update(Product product)
        {
            if (!User.IsInRole("Admin")) return Unauthorized();
            if (ModelState.IsValid)
            {
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!User.IsInRole("Admin")) return Unauthorized();
            unitOfWork.ProductRepository.Delete(id);
            unitOfWork.Complete();
            return NoContent();
        }
        [HttpGet("Products/Category/{categoryId}")]
        public IActionResult GetProductsFromCategory(int categoryId)
        {
            var products = unitOfWork.ProductRepository.GetProductsFromCategory(categoryId);
            if(products == null) return NotFound();
            return Ok(products);
        }
        [HttpGet("Products/{productId}/Sizes")]
        public IActionResult GetProductSizes(int productId)
        {
            return Ok();
        }
    }
}
