using ReadIt.ViewModels;

namespace ReadIt.Repositories.Blog
{
    public interface IBlogRepository
    {
        public ResponseDataModel<BlogModel> GetById(long id);
        public ResponseListModel<BlogModel> GetBlogs(PaginationModel pagination,long categoryId = 0);
        public ResponseListModel<BlogModel> RecentByCount(int count, long blogId = 0, long userId = 0);
    }
}
