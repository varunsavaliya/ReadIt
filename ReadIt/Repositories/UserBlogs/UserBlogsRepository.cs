﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadIt.Extentions.ImageExtention;
using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.UserBlogs
{
    public class UserBlogsRepository : IUserBlogsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageExtension<TbBlog> _imageExtention;
        public UserBlogsRepository(ApplicationDbContext context, IMapper mapper, Extentions.ImageExtention.IImageExtension<TbBlog> imageExtention)
        {
            _context = context;
            _mapper = mapper;
            _imageExtention = imageExtention;
        }
        public ResponseModel Create(BlogModel blog)
        {
            ResponseModel response = new ResponseModel();
            try
            {

                TbBlog tbBlog = _mapper.Map<TbBlog>(blog);
                tbBlog.CreatedOn = DateTime.Now;
                tbBlog.Category = null;
                _context.TbBlogs.Add(tbBlog);

                _context.SaveChanges();
                if (blog.BlogImage != null)
                {
                    TbBlog newBlog = _context.TbBlogs.FirstOrDefault(dbblog => dbblog.Title == blog.Title);
                    _imageExtention.AddImages(blog.BlogImage, tbBlog);
                }


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

                if (blog.BlogImage != null)
                {
                    _imageExtention.DeleteImages(id);
                    _imageExtention.AddImages(blog.BlogImage, tbBlog);
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
            if (oldMediaPath != null)
            {
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

        public ResponseListModel<BlogModel> GetAllByUserId(long userId)
        {
            ResponseListModel<BlogModel> response = new();
            try
            {
                List<TbBlog> blogs = _context.TbBlogs.Where(blog => blog.CreatedBy == userId && blog.IsActive == true).Include(blog => blog.Category).Include(blog => blog.CreatedByNavigation).ToList();
                List<BlogModel> allBlogs = new();
                foreach (var blog in blogs)
                {
                    BlogModel blogModel = _mapper.Map<BlogModel>(blog);
                    blogModel.User = _mapper.Map<UserModel>(blog.CreatedByNavigation);
                    blogModel.User.Password = null;
                    blogModel.CategoryName = blog.Category.Name;
                    allBlogs.Add(blogModel);
                }
                response.Items = allBlogs;
                response.Success = true;
                response.Message = "Blogs retrived successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
