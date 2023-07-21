using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;
using User.Microservice.Repository;

namespace ReadIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ResponseDataModel<UserModel> GetById([FromRoute] long id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost("edit/{id}")]
        public ResponseModel EditUser([FromRoute] long id, [FromForm] UserModel user)
        {
            return _userService.EditUser(id, user);
        }
    }
}
