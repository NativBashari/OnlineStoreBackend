using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ProductsManagement;

namespace OnlineStoreBackend.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    //[ApiController]
    //public class InventoriesController : ControllerBase
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public InventoriesController(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    [HttpGet]
    //    public IActionResult GetAll()
    //    {
    //        var inventories = unitOfWork.InventoryRepository.GetAll();
    //        return Ok(inventories);
    //    }
    //    [HttpGet("{id}")]
    //    public IActionResult Get(int id)
    //    {
    //        var inventory = unitOfWork.InventoryRepository.Get(id);
    //        if (inventory == null) return NotFound();
    //        return Ok(inventory);
    //    }
    //    [Authorize(Roles = "Admin")]
    //    [HttpPost]
    //    public IActionResult Post(Inventory inventory)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            unitOfWork.InventoryRepository.Create(inventory);
    //            unitOfWork.Complete();
    //            return Created("Inventory created succesfully", inventory);
    //        }
    //        return BadRequest();
    //    }
    //    [HttpPut]
    //    public IActionResult Update(Inventory inventory)
    //    {
    //        if (!User.IsInRole("Admin")) return Unauthorized();
    //        if (ModelState.IsValid)
    //        {
    //            unitOfWork.InventoryRepository.Update(inventory);
    //            unitOfWork.Complete();
    //            return NoContent();
    //        }
    //        return BadRequest();
    //    }
    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        if (!User.IsInRole("Admin")) return Unauthorized();
    //        unitOfWork.InventoryRepository.Delete(id);
    //        unitOfWork.Complete();
    //        return NoContent();
    //    }
    //}
}
