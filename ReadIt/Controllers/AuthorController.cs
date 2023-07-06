using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Repositories.Author;
using ReadIt.ViewModels;

namespace ReadIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorService;

        public AuthorController(IAuthorRepository authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ResponseListModel<UserModel> GetAuthors([FromQuery] PaginationModel pagination)
        {
            return _authorService.GetAuthors(pagination);
        }
    }
}
