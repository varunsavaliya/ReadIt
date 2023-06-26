using AutoMapper;
using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.Category
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseListModel<CategoryModel> GetAll()
        {
            ResponseListModel<CategoryModel> response = new();
            try
            {
                List<CategoryModel> categoryList = new();
                List<TbCategory> categories = _context.TbCategories.Where(category => category.IsActive == true).ToList();
                foreach (TbCategory category in categories)
                {
                    categoryList.Add(_mapper.Map<CategoryModel>(category));
                }
                response.Items = categoryList;
                response.Success = true;
                response.Message = "Category list retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseDataModel<CategoryModel> GetById(long id)
        {
            ResponseDataModel<CategoryModel> response = new();
            try
            {
                response.Data = _mapper.Map<CategoryModel>(_context.TbCategories.Find(id));
                response.Success = true;
                response.Message = "Category retrieved successfully";
            }
            catch(Exception ex)
            {
                response.Success=false;
                response.Message=ex.Message;
            }
            return response;
        }
    }
}
