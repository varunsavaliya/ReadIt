using ReadIt.ViewModels;

namespace ReadIt.Repositories.UserBlogs
{
    public interface IUserBlogsRepository
    {
        public ResponseListModel<BlogModel> GetAllByUserId(long userId);
        public ResponseModel Create(BlogModel blog);

        public ResponseModel Update(BlogModel blog, long id);

        public ResponseModel Delete(long id);
    }
}
