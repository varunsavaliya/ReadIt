using ReadIt.ViewModels;

namespace ReadIt.Repositories.Comment
{
    public interface ICommentRepository
    {
        public ResponseDataModel<CommentModel> GetById(long id);
        public ResponseListModel<CommentModel> GetAllByBlogId(long id, bool showAllComments);

        public ResponseModel Create(CommentModel comment);

    }
}
