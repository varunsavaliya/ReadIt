using Microsoft.AspNetCore.Mvc;
using ReadIt.Repositories.Category;
using ReadIt.ViewModels;

namespace ReadIt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;

        public CategoryController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public ResponseDataModel<CategoryModel> GetById([FromRoute] long id)
        {
            return _categoryService.GetById(id);
        }
        [HttpGet]
        public ResponseListModel<CategoryModel> GetAll()
        {
            return _categoryService.GetAll();
        }
    }
}
