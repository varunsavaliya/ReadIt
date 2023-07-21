
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;

namespace Comment.Microservice.Repository
{
    public interface ICommentRepository
    {
        public ResponseDataModel<CommentModel> GetById(long id);
        public ResponseListModel<CommentModel> GetAllByBlogId(long id, bool showAllComments);

        public Task<ResponseModel> Create(CommentModel comment);

    }
}
