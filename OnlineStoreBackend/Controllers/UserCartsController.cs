using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models.ProductsManagement;
using Models.UserManagement;

namespace OnlineStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UserCartsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userCart =  unitOfWork.UserCartRepository.GetByUserId(id);
            if(userCart == null) return NotFound();
            return Ok(userCart);
        }
        [HttpGet("Products/UserCarts/{userCartId}")]
        public IActionResult GetUserCartProducts(int userCartId)
        {
            var products = unitOfWork.UserCartRepository.GetUserCartProducts(userCartId);
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post(UserCart userCart)
        {
            var products = new List<Product>();
            foreach (var item in userCart.Products!)
            {
                products.Add(unitOfWork.ProductRepository.Get(item.Id));
            }
            userCart.Products = products;
            unitOfWork.UserCartRepository.Create(userCart);
            unitOfWork.Complete();
            return Created("Cart Created Succesfully", userCart);
        }
        [HttpPut]
        public IActionResult Put(UserCart userCart)
        {
            var products = new List<Product>();
            foreach (var item in userCart.Products!)
            {
                products.Add(unitOfWork.ProductRepository.Get(item.Id));
                item.UserCarts!.Remove(userCart);
                item.UserCarts!.Add(userCart);

            }
            userCart.Products = products;
            unitOfWork.UserCartRepository.Update(userCart);
            unitOfWork.Complete();
            return Created("Cart updated succesfully", userCart);
        }

        [HttpGet("RemoveFromCart/{userCartId}/{productId}")]
        public IActionResult RemoveProductFromCart(int userCartId, int productId)
        {
            var uc = unitOfWork.UserCartRepository.Get(userCartId);
            var product = unitOfWork.ProductRepository.Get(productId);
            uc.Products = unitOfWork.UserCartRepository.GetUserCartProducts(userCartId).ToList();
            uc.Products!.Remove(product);
            unitOfWork.Complete();
            return Ok(); //Work good!
        }
        [HttpGet("AddToCart/{userCartId}/{productId}")]
        public IActionResult AddProductToCart(int userCartId, int productId)
        {
            var uc = unitOfWork.UserCartRepository.Get(userCartId);
            var product = unitOfWork.ProductRepository.Get(productId);
            uc.Products = unitOfWork.UserCartRepository.GetUserCartProducts(userCartId).ToList();
            uc.Products.Add(product);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
