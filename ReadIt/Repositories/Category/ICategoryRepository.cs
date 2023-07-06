using ReadIt.ViewModels;

namespace ReadIt.Repositories.Category
{
    public interface ICategoryRepository
    {
        public ResponseListModel<CategoryModel> GetCategories(string searchText = null);
        public ResponseDataModel<CategoryModel> GetById(long id);
    }
}
