
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Comment.Microservice.Repository
{
    public interface ICommentRepository
    {
        public ResponseDataModel<CommentModel> GetById(long id);
        public ResponseListModel<CommentModel> GetAllByBlogId(long id, bool showAllComments);

        public ResponseModel Create(CommentModel comment);

    }
}
