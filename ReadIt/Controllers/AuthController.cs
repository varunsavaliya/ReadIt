using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Repositories.Auth;
using ReadIt.ViewModels;

namespace ReadIt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;

        public AuthController(IAuthRepository auth)
        {
            _auth = auth;
        }
        [HttpPost("login")]
        public AuthModel Login([FromBody] UserModel user)
        {
            return _auth.CheckLogin(user);
        }

        [HttpPost("signup")]
        public AuthModel SignUp([FromBody] UserModel user)
        {
            return _auth.SignUpUser(user);
        }

        [HttpPost("changePassword")]
        [Authorize]
        public ResponseModel ChangePassword(ChangePasswordModel model)
        {
            return _auth.ChangePassword(model);
        }
    }
}
