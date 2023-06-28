using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Repositories.Blog;
using ReadIt.ViewModels;

namespace ReadIt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogService;

        public BlogController(IBlogRepository blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public ResponseListModel<BlogModel> GetAll()
        {
            return _blogService.GetAll();
        }

        [HttpGet("{id}")]
        public ResponseDataModel<BlogModel> GetById([FromRoute]long id)
        {
            return _blogService.GetById(id);
        }

        [HttpPost]
        [Authorize]
        public ResponseModel Create([FromBody] BlogModel blog)
        {
            return _blogService.Create(blog);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ResponseModel Update([FromBody] BlogModel blog, [FromRoute] long id)
        {
            return _blogService.Update(blog, id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ResponseModel Delete([FromRoute] long id)
        {
            return _blogService.Delete(id);
        }
    }
}
