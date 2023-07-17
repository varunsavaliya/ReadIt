using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Author.microservice.Repository
{
    public interface IAuthorRepository
    {
        public ResponseListModel<UserModel> GetAuthors(PaginationModel pagination);
    }
}
