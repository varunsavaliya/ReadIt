using Blog.Microservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Blog.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return _blogService.GetBlogs(pagination, id);
        }

        [HttpGet("{id}")]
        public ResponseDataModel<BlogModel> GetById([FromRoute] long id)
        {
            return _blogService.GetById(id);
        }

        [HttpGet("recent/{count}/{blogId}/{userId}")]
        public ResponseListModel<BlogModel> RecentByCountAndCategory([FromRoute] int count, [FromRoute] long blogId, [FromRoute] long userId)
        {
            return _blogService.RecentByCount(count, blogId, userId);
        }
        [HttpGet("recent/{count}")]
        public ResponseListModel<BlogModel> RecentByCount([FromRoute] int count)
        {
            return _blogService.RecentByCount(count);
        }
    }
}
