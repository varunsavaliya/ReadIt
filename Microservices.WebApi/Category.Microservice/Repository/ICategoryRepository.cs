using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;

namespace Category.Microservice.Repository
{
    public interface ICategoryRepository
    {
        public ResponseListModel<CategoryModel> GetCategories(string searchText = null);
        public ResponseDataModel<CategoryModel> GetById(long id);
    }
}
