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
        public ResponseListModel<BlogModel> GetAll([FromQuery] PaginationModel pagination)
        {
            return _blogService.GetBlogs(pagination);
        }
        [HttpGet("category/{id}")]
        public ResponseListModel<BlogModel> GetByCategoryId([FromRoute] long id, [FromQuery] PaginationModel pagination)
        {
            return _blogService.GetBlogs(pagination,id);
        }

        [HttpGet("{id}")]
        public ResponseDataModel<BlogModel> GetById([FromRoute]long id)
        {
            return _blogService.GetById(id);
        }

        [HttpGet("recent/{count}/{blogId}/{categoryId}")]
        public ResponseListModel<BlogModel> RecentByCountAndCategory([FromRoute] int count,[FromRoute] long blogId, [FromRoute] long categoryId)
        {
            return _blogService.RecentByCount(count, blogId, categoryId);
        }
        [HttpGet("recent/{count}")]
        public ResponseListModel<BlogModel> RecentByCount([FromRoute] int count)
        {
            return _blogService.RecentByCount(count);
        }
    }
}
