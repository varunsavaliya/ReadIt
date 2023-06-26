using ReadIt.ViewModels;

namespace ReadIt.Repositories.Comment
{
    public interface ICommentRepository
    {
        public ResponseDataModel<CommentModel> GetById(long id);
        public ResponseListModel<CommentModel> GetAll();

        public ResponseModel Create(CommentModel comment);

    }
}
