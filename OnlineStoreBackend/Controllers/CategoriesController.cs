using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ProductsManagement;

namespace OnlineStoreBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = unitOfWork.CategoryRepository.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = unitOfWork.CategoryRepository.Get(id);
            if (category == null) return NotFound();
            return Ok(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepository.Create(category);
                unitOfWork.Complete();
                return Created("Category created succesfully", category);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            if (!User.IsInRole("Admin")) return Unauthorized();
            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepository.Update(category);
                unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!User.IsInRole("Admin")) return Unauthorized(); //Correct!!

            unitOfWork.CategoryRepository.Delete(id);
            unitOfWork.Complete();
            return NoContent();
        }
    }
}
