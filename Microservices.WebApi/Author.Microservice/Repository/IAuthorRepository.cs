using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;

namespace Author.microservice.Repository
{
    public interface IAuthorRepository
    {
        public ResponseListModel<UserModel> GetAuthors(PaginationModel pagination);
    }
}
