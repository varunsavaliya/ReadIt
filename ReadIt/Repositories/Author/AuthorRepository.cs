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
        public ResponseListModel<UserModel> GetAuthors(PaginationModel pagination)
        {
            ResponseListModel<UserModel> response = new();
            try
            {
                var usersQuery = _context.TbUsers.Where(user => user.TbBlogs.Any()).Include(user => user.TbBlogs);
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
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Profile Images", user.Avatar);
                        byte[] fileBytes = File.ReadAllBytes(filePath);
                        string base64String = Convert.ToBase64String(fileBytes);
                        userModel.Avatar = base64String;
                    }

                    items.Add(userModel);
                }
                response.Items = items;
                response.TotalItems = totalUsers;
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
