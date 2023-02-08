using Contracts.RepositoriesContracts.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.UserManagement;

namespace OnlineStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDto request)
        {
            var response = authRepository.Register(
                new User {Username = request.Username, FirstName = request.FirstName, LastName = request.LastName, Telephone = request.Telephone, CreatedAt = request.CreatedAt}, request.Password!
                );
            if (response == 0) return BadRequest();
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto request)
        {
            var response = authRepository.Login(request.Username, request.Password);
            if (!response.IsSuccess) return BadRequest(response);
            return Ok(response);
        }
    }
}
