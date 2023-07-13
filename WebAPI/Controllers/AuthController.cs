

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            this._authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register (UserRegisterDTO request)
        {
            var response = await _authRepo.Register(
                new User{UserName = request.UserName}, request.Password
            );

            return (!response.Success) ? BadRequest(response) : Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login (UserLoginDTO request)
        {
            var response = await _authRepo.Login(request.UserName, request.Password);

            return (!response.Success) ? BadRequest(response) : Ok(response);
        }
    }
}