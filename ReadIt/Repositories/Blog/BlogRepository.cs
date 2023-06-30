using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BlogRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseDataModel<BlogModel> GetById(long id)
        {
            ResponseDataModel<BlogModel> response = new();
            try
            {
                var tbBlog = _context.TbBlogs.Where(blog => blog.Id == id && blog.IsActive == true).Include(blog => blog.CreatedByNavigation).Include(blog => blog.Category).FirstOrDefault();
                var data = _mapper.Map<BlogModel>(tbBlog);
                data.CategoryName = tbBlog.Category.Name;
                data.CreatedByName = tbBlog.CreatedByNavigation.Name;

                if (data != null)
                {
                    response.Data = data;
                    response.Success = true;
                    response.Message = "Blog retrived successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error occured while retriving blog";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseListModel<BlogModel> GetAll()
        {
            ResponseListModel<BlogModel> response = new();
            try
            {
                List<TbBlog> blogs = _context.TbBlogs.Where(blog => blog.IsActive == true).Include(blog => blog.Category).Include(blog => blog.CreatedByNavigation).ToList();
                List<BlogModel> allBlogs = new();
                foreach (var blog in blogs)
                {
                    BlogModel blogModel = _mapper.Map<BlogModel>(blog);
                    blogModel.CreatedByName = blog.CreatedByNavigation.Name;
                    blogModel.CategoryName = blog.Category.Name;
                    allBlogs.Add(blogModel);
                }
                response.Items = allBlogs;
                response.Success = true;
                response.Message = "Blogs retrived successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        
    }
}
