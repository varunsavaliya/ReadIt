using Author.microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Author.microservice.Controllers
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
