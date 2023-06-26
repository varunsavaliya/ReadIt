using ReadIt.ViewModels;

namespace ReadIt.Repositories.Category
{
    public interface ICategoryRepository
    {
        public ResponseListModel<CategoryModel> GetAll();
        public ResponseDataModel<CategoryModel> GetById(long id);
    }
}
