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
    public class DiscountsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DiscountsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var discounts = unitOfWork.DiscountRepository.GetAll();
            if (discounts == null) return NotFound();
            return Ok(discounts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var discount = unitOfWork.DiscountRepository.Get(id);
            if(discount == null) return NotFound();
            return Ok(discount);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(Discount discount)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DiscountRepository.Create(discount);
                unitOfWork.Complete();
                return Created("Discount created succesfully", discount);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(Discount discount)
        {
            if (!User.IsInRole("Admin")) return Unauthorized();
            if (ModelState.IsValid)
            {
                unitOfWork.DiscountRepository.Update(discount);
                unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!User.IsInRole("Admin")) return Unauthorized(); 
            unitOfWork.DiscountRepository.Delete(id);
            unitOfWork.Complete();
            return NoContent();
        }
    }
}
