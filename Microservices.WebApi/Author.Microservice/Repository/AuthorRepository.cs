using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadIt.Core.Constants;
using ReadIt.Entities.Models;
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;
using ReadIt.Extentions.ImageExtention;

namespace Author.microservice.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageHandler<TbUser> _imageExtension;

        public AuthorRepository(ApplicationDbContext context, IMapper mapper, IImageHandler<TbUser> imageExtension)
        {
            _context = context;
            _mapper = mapper;
            _imageExtension = imageExtension;
        }
        public ResponseListModel<UserModel> GetAuthors(PaginationModel pagination)
        {
            ResponseListModel<UserModel> response = new();
            try
            {
                var usersQuery = _context.TbUsers.Where(user => user.TbBlogs.Any(blog => blog.IsActive == true) && user.IsActive == true).Include(user => user.TbBlogs);
                var totalUsers = usersQuery.Count();
                var users = usersQuery.Skip(pagination.PageSize * (pagination.CurrentPage - 1)).Take(pagination.PageSize).ToList();
                List<UserModel> items = new();
                foreach (var user in users)
                {
                    user.Password = null;
                    var userModel = _mapper.Map<UserModel>(user);
                    userModel.TotalBlogs = user.TbBlogs.Where(blog => blog.IsActive == true).Count();

                    if (user.Avatar != null)
                    {
                        userModel.Avatar = _imageExtension.GetImage(user);
                    }

                    items.Add(userModel);
                }
                response.Items = items;
                response.TotalItems = totalUsers;
                response.Success = true;
                response.Message = String.Format(Messages.SuccessMessage, "Authors retrived");
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
