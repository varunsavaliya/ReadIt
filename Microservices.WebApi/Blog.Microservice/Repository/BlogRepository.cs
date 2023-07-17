using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadIt.Core.Constants;
using ReadIt.Entities.Models;
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;
using ReadIt.Extentions.ImageExtention;

namespace Blog.Microservice.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageExtension<TbBlog> _imageExtention;

        public BlogRepository(ApplicationDbContext context, IMapper mapper, IImageExtension<TbBlog> imageExtention)
        {
            _context = context;
            _mapper = mapper;
            _imageExtention = imageExtention;
        }

        public ResponseDataModel<BlogModel> GetById(long id)
        {
            ResponseDataModel<BlogModel> response = new();
            try
            {
                var tbBlog = _context.TbBlogs.Where(blog => blog.Id == id && blog.IsActive == true).Include(blog => blog.CreatedByNavigation).Include(blog => blog.Category).Include(blog => blog.TbComments).ThenInclude(comment => comment.CreatedByNavigation).FirstOrDefault();
                if (tbBlog != null)
                {

                    var data = _mapper.Map<BlogModel>(tbBlog);
                    data.CategoryName = tbBlog.Category.Name;
                    data.User = _mapper.Map<UserModel>(tbBlog.CreatedByNavigation);
                    data.User.Password = null;
                    if (data.User.Avatar != null)
                    {
                        var filePath = Path.Combine(Constants.MediaPath, "Media", "Profile Images", data.User.Avatar);
                        byte[] fileBytes = File.ReadAllBytes(filePath);
                        string base64String = Convert.ToBase64String(fileBytes);
                        data.User.Avatar = base64String;
                    }
                    //List<TbComment> tbBlogComments = tbBlog.TbComments.ToList();
                    //List<CommentModel> blogComments = new();
                    //foreach (var blogComment in tbBlogComments)
                    //{
                    //    var comment = _mapper.Map<CommentModel>(blogComment);
                    //    if (blogComment.CreatedBy != null)
                    //    {
                    //        comment.User = _mapper.Map<UserModel>(blogComment.CreatedByNavigation);
                    //        comment.User.Password = null;
                    //    }

                    //    //if (comment.User.Avatar != null)
                    //    //{
                    //    //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Profile Images", data.User.Avatar);
                    //    //    byte[] fileBytes = File.ReadAllBytes(filePath);
                    //    //    string base64String = Convert.ToBase64String(fileBytes);
                    //    //    comment.User.Avatar = base64String;
                    //    //}
                    //    blogComments.Add(comment);
                    //}
                    data.TotalComments = tbBlog.TbComments.Select(comment => comment.IsActive == true).Count();
                    data.BlogImageUrl = _imageExtention.GetImage(tbBlog);

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
                else
                {
                    response.Success = false;
                    response.Message = "No blog found with this id";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseListModel<BlogModel> GetBlogs(PaginationModel pagination, long categoryId = 0)
        {
            ResponseListModel<BlogModel> response = new();
            try
            {
                var query = _context.TbBlogs.Where(blog => blog.IsActive == true && blog.CreatedByNavigation.IsActive == true);
                if (categoryId != 0)
                    query = query.Where(blog => blog.CategoryId == categoryId);

                response.TotalItems = query.Count();

                List<TbBlog> blogs = query.OrderByDescending(blog => blog.CreatedOn).Include(blog => blog.Category).Include(blog => blog.CreatedByNavigation).Skip(pagination.PageSize * (pagination.CurrentPage - 1)).Take(pagination.PageSize).ToList();
                List<BlogModel> allBlogs = new();
                foreach (var blog in blogs)
                {
                    BlogModel blogModel = _mapper.Map<BlogModel>(blog);
                    List<CommentModel> blogComments = new();

                    blogModel.User = _mapper.Map<UserModel>(blog.CreatedByNavigation);
                    blogModel.User.Password = null;
                    //var blogTbComments = blog.TbComments.Select(comment => comment.IsActive == true).ToList();
                    //foreach (var blogComment in blogTbComments)
                    //{
                    //    blogComments.Add(_mapper.Map<CommentModel>(blogComment));
                    //}
                    blogModel.TotalComments = blog.TbComments.Select(comment => comment.IsActive == true).Count();
                    blogModel.BlogImageUrl = _imageExtention.GetImage(blog);

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
        public ResponseListModel<BlogModel> RecentByCount(int count, long blogId = 0, long userId = 0)
        {
            ResponseListModel<BlogModel> response = new();
            try
            {
                List<TbBlog> blogs = new();
                var blogsquery = _context.TbBlogs.Where(blog => blog.IsActive == true);
                if (userId != 0)
                {
                    blogsquery = blogsquery.Where(blog => blog.Id != blogId && blog.CreatedBy == userId);
                }

                blogs = blogsquery.Include(blog => blog.Category).Include(blog => blog.CreatedByNavigation).OrderByDescending(blog => blog.CreatedOn).Take(count).ToList();
                List<BlogModel> allBlogs = new();
                foreach (var blog in blogs)
                {
                    BlogModel blogModel = _mapper.Map<BlogModel>(blog);
                    List<CommentModel> blogComments = new();

                    blogModel.User = _mapper.Map<UserModel>(blog.CreatedByNavigation);
                    blogModel.User.Password = null;
                    //var blogTbComments = blog.TbComments.Select(comment => comment.IsActive == true).ToList();
                    //foreach (var blogComment in blogTbComments)
                    //{
                    //    blogComments.Add(_mapper.Map<CommentModel>(blogComment));
                    //}
                    blogModel.TotalComments = blog.TbComments.Select(comment => comment.IsActive == true).Count();
                    blogModel.BlogImageUrl = _imageExtention.GetImage(blog);

                    blogModel.CategoryName = blog.Category.Name;
                    allBlogs.Add(blogModel);
                }
                response.Items = allBlogs;
                response.Success = true;
                response.Message = count + " blogs retrived successfully";
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
