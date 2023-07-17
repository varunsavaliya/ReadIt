using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Category.Microservice.Repository
{
    public interface ICategoryRepository
    {
        public ResponseListModel<CategoryModel> GetCategories(string searchText = null);
        public ResponseDataModel<CategoryModel> GetById(long id);
    }
}
