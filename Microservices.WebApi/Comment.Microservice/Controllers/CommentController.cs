using Comment.Microservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace ReadIt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentService;

        public CommentController(ICommentRepository commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public ResponseModel Create([FromBody] CommentModel comment)
        {
            return _commentService.Create(comment);
        }

        //[HttpGet("{id}")]
        //public ResponseDataModel<CommentModel> GetById([FromRoute] long id)
        //{
        //    return _commentService.GetById(id);
        //}

        [HttpGet]
        public ResponseListModel<CommentModel> GetAllByBlogId([FromQuery] long id, bool showAllComments)
        {
            return _commentService.GetAllByBlogId(id, showAllComments);
        }
    }
}
