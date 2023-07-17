using Auth.Microservice.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Auth.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;

        public AuthController(IAuthRepository auth)
        {
            _auth = auth;
        }
        [HttpGet("login")]
        public AuthModel Login([FromQuery] string email, string password)
        {
            return _auth.CheckLogin(email, password);
        }

        [HttpPost("signup")]
        public AuthModel SignUp([FromBody] UserModel user)
        {
            return _auth.SignUpUser(user);
        }

        [HttpPost("changePassword")]
        //[Authorize]
        public ResponseModel ChangePassword(ChangePasswordModel model)
        {
            return _auth.ChangePassword(model);
        }
    }
}
