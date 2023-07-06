using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Repositories.Blog;
using ReadIt.Repositories.UserBlogs;
using ReadIt.ViewModels;

namespace ReadIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserBlogsController : ControllerBase
    {
        private readonly IUserBlogsRepository _userBlogsService;
        private readonly IBlogRepository _blogService;

        public UserBlogsController(IUserBlogsRepository userBlogsService, IBlogRepository blogService)
        {
            _userBlogsService = userBlogsService;
            _blogService = blogService;
        }

        [HttpGet("{id}")]
        public ResponseDataModel<BlogModel> GetById([FromRoute] long id)
        {
            return _blogService.GetById(id);
        }

        [HttpGet("all/{userId}")]
        public ResponseListModel<BlogModel> GetAllByUserId([FromRoute] long userId)
        {
            return _userBlogsService.GetAllByUserId(userId);
        }

        [HttpPost]
        public ResponseModel Create([FromForm] BlogModel blog)
        {
            return _userBlogsService.Create(blog);
        }

        [HttpPut("{id}")]
        public ResponseModel Update([FromForm] BlogModel blog, [FromRoute] long id)
        {
            return _userBlogsService.Update(blog, id);
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete([FromRoute] long id)
        {
            return _userBlogsService.Delete(id);
        }
    }
}
