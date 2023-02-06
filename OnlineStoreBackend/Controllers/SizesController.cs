//using Contracts;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Models.ProductsManagement;

//namespace OnlineStoreBackend.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SizesController : ControllerBase
//    {
//        private readonly IUnitOfWork unitOfWork;

//        public SizesController(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            var sizes = unitOfWork.SizeRepository.GetAll();
//            if (sizes == null) return BadRequest();
//            return Ok(sizes);
//        }
//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            var size = unitOfWork.SizeRepository.Get(id);
//            if(size == null) return BadRequest();
//            return Ok(size);
//        }
//        [HttpPut]
//        public IActionResult Update(Size size)
//        {
//            if (!User.IsInRole("Admin")) return Unauthorized();
//            if (ModelState.IsValid)
//            {
//                unitOfWork.SizeRepository.Update(size);
//                unitOfWork.Complete();
//                return NoContent();
//            }
//            return BadRequest();
//        }
//        [HttpPost]
//        public IActionResult Post(Size size)
//        {
//            if (!User.IsInRole("Admin")) return Unauthorized();
//            if (ModelState.IsValid)
//            {
//                unitOfWork.SizeRepository.Create(size);
//                unitOfWork.Complete();
//                return Created("Size created.", size);
//            }
//            return BadRequest();
//        }
//        [HttpDelete ("{id}")]
//        public IActionResult Delete(int id)
//        {
//            if (!User.IsInRole("Admin")) return Unauthorized();
//            unitOfWork.SizeRepository.Delete(id);
//            unitOfWork.Complete();
//            return NoContent();
//        }
    
//    }
//}
