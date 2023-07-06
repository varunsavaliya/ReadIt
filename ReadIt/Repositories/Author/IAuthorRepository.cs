using ReadIt.ViewModels;

namespace ReadIt.Repositories.Author
{
    public interface IAuthorRepository
    {
        public ResponseListModel<UserModel> GetAuthors(PaginationModel pagination);
    }
}
