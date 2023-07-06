
namespace ReadIt.ViewModels
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Bio { get; set; }

        public string Avatar { get; set; }
        public IFormFile AvatarImage { get; set; }
        public long TotalBlogs { get; set; }
    }
}
