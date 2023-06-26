using AutoMapper;
using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.Comment
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResponseDataModel<CommentModel> GetById(long id)
        {
            ResponseDataModel<CommentModel> response = new();
            try
            {
                response.Data = _mapper.Map<CommentModel>(_context.TbComments.Find(id));
                response.Success = true;
                response.Message = "Comment retrived successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = true;
            }
            return response;
        }

        public ResponseListModel<CommentModel> GetAll()
        {
            ResponseListModel<CommentModel> response = new();
            try
            {
                List<TbComment> tbComments = _context.TbComments.Where(comment => comment.IsActive == true).ToList();
                List<CommentModel> comments = new();

                foreach (TbComment tbComment in tbComments)
                {
                    comments.Add(_mapper.Map<CommentModel>(tbComment));
                }

                response.Items = comments;
                response.Success = true;
                response.Message = "Comments retrived successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public ResponseModel Create(CommentModel comment)
        {
            ResponseModel response = new();
            try
            {
                TbComment tbComment = _mapper.Map<TbComment>(comment);
                _context.TbComments.Add(tbComment);
                _context.SaveChanges();

                response.Message = "Comment added successfully";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
