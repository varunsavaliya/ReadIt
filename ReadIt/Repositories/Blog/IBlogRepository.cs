using ReadIt.ViewModels;

namespace ReadIt.Repositories.Blog
{
    public interface IBlogRepository
    {
        public ResponseDataModel<BlogModel> GetById(long id);
        public ResponseListModel<BlogModel> GetAll();
        

    }
}
