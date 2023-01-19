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
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(Discount discount)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DiscountRepository.Update(discount);
                unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            unitOfWork.DiscountRepository.Delete(id);
            unitOfWork.Complete();
            return NoContent();
        }
    }
}
