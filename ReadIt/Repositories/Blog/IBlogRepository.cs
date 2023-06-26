using ReadIt.ViewModels;

namespace ReadIt.Repositories.Blog
{
    public interface IBlogRepository
    {
        public ResponseDataModel<BlogModel> GetById(long id);
        public ResponseListModel<BlogModel> GetAll();
        public ResponseModel Create(BlogModel blog);

        public ResponseModel Update(BlogModel blog, long id);

        public ResponseModel Delete(long id);

    }
}
