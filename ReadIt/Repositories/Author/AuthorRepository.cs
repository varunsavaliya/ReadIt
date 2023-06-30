using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.Author
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResponseListModel<UserModel> GetAll()
        {
            ResponseListModel<UserModel> response = new();
            try
            {
                var users = _context.TbUsers.Where(user => user.TbBlogs.Any()).Include(user => user.TbBlogs).ToList();
                List<UserModel> items = new();
                foreach (var user in users)
                {
                    user.Password = null;
                    var userModel = _mapper.Map<UserModel>(user);
                    userModel.TotalBlogs = user.TbBlogs.Where(blog => blog.IsActive == true).Count();
                    items.Add(userModel);
                }
                response.Items = items;
                response.Success = true;
                response.Message = "Authors retrieved successfully";
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
