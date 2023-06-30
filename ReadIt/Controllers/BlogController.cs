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

        
    }
}
