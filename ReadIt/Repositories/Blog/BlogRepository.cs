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
                var data = _mapper.Map<BlogModel>(_context.TbBlogs.Find(id));
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
                List<TbBlog> blogs = _context.TbBlogs.Where(blog => blog.IsActive == true).Include(blog => blog.CreatedByNavigation).ToList();
                List<BlogModel> allBlogs = new();
                foreach (var blog in blogs)
                {
                    BlogModel blogModel = _mapper.Map<BlogModel>(blog);
                    blogModel.CreatedByName = blog.CreatedByNavigation.Name;
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
        public ResponseModel Create(BlogModel blog)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                TbBlog tbBlog = _mapper.Map<TbBlog>(blog);
                _context.TbBlogs.Add(tbBlog);


                if (blog.file != null)
                {
                    TbBlog newBlog = _context.TbBlogs.FirstOrDefault(dbblog => dbblog.Title == blog.Title);
                    AddImages(blog.file, newBlog);
                }
                tbBlog.Title = blog.Title;
                tbBlog.Description = blog.Description;
                tbBlog.Tags = blog.Tags;
                tbBlog.UpdatedOn = DateTime.Now;

                _context.SaveChanges();

                response.Message = "Your blog has been added successfully";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public ResponseModel Update(BlogModel blog, long id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                TbBlog tbBlog = _context.TbBlogs.Find(id);
                tbBlog.Title = blog.Title;
                tbBlog.Description = blog.Description;
                tbBlog.Tags = blog.Tags;
                tbBlog.UpdatedOn = DateTime.Now;

                _context.SaveChanges();

                if(blog.file != null)
                {
                    DeleteImages(id);
                    AddImages(blog.file, tbBlog);
                }

                response.Message = "Your blog has been updated successfully";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public ResponseModel Delete(long id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                TbBlog tbBlog = _context.TbBlogs.Find(id);
                tbBlog.IsActive = false;

                _context.SaveChanges();

                response.Success = true;
                response.Message = "Your Blog has been deleted successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private void DeleteImages(long id)
        {
            var existingMedia = _context.TbBlogMedia.FirstOrDefault(media => media.Id == id);
            string oldMediaPath = null;

            if (existingMedia != null)
            {
                oldMediaPath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Blog Images", existingMedia.MediaPath);
            }
            // delete the previous images from the server's directory
            foreach (var file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Media", "Blog Images")))
            {
                if (oldMediaPath.Contains(file))
                {
                    System.IO.File.Delete(file);
                }
            }
            _context.RemoveRange(existingMedia);
            _context.SaveChanges();
        }

        private void AddImages(IFormFile file, TbBlog newBlog)
        {
            var fileName = "Blog_Image_" + newBlog.Id + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Blog Images", fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            TbBlogMedium media = new();
            media.BlogId = newBlog.Id;
            media.MediaPath = fileName;

            _context.TbBlogMedia.Add(media);
            _context.SaveChanges();
        }
    }
}
