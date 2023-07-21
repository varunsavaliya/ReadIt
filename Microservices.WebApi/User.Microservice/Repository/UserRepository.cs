
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadIt.Core.Constants;
using ReadIt.Core.DataModels;
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;
using ReadIt.Extentions.ImageExtention;

namespace User.Microservice.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageHandler<TbUser> _imageExtention;

        public UserRepository(ApplicationDbContext context, IMapper mapper, IImageHandler<TbUser> imageExtention)
        {
            _context = context;
            _mapper = mapper;
            _imageExtention = imageExtention;
        }

        public ResponseDataModel<UserModel> GetUserById(long id)
        {
            ResponseDataModel<UserModel> response = new();
            try
            {
                TbUser tbUser = _context.TbUsers.Where(user => user.Id == id && user.IsActive == true).Include(user => user.TbBlogs).FirstOrDefault();
                tbUser.Password = null;
                UserModel user = _mapper.Map<UserModel>(tbUser);
                user.TotalBlogs = tbUser.TbBlogs.Where(blog => blog.IsActive == true).Count();
                user.Avatar = _imageExtention.GetImage(tbUser);
                response.Data = user;
                response.Success = true;
                response.Message = String.Format(Messages.SuccessMessage, "User details retrived");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public ResponseModel EditUser(long id, UserModel user)
        {
            ResponseModel response = new();
            try
            {
                TbUser tbUser = _context.TbUsers.Find(id);
                tbUser.Name = user.Name;
                tbUser.Bio = user.Bio;

                _context.SaveChanges();
                if (user.AvatarImage != null)
                {
                    _imageExtention.DeleteImages(id);
                    _imageExtention.AddImages(user.AvatarImage, tbUser);
                }
                response.Success = true;
                response.Message = String.Format(Messages.UpdateMessage, "User details");
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
