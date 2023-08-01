using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Notification.Microservice.Models;
using Notification.Microservice.Repository;
using ReadIt.Core.Constants;
using ReadIt.Core.DataModels;
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;
using ReadIt.Extentions.ImageExtention;

namespace Comment.Microservice.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageHandler<TbUser> _imageExtension;
        private readonly IHubContext<NotifyHub, INotificationHub> _notify;

        public CommentRepository(ApplicationDbContext context, IMapper mapper, IImageHandler<TbUser> imageExtension, IHubContext<NotifyHub, INotificationHub> notify)
        {
            _context = context;
            _mapper = mapper;
            _imageExtension = imageExtension;
            _notify = notify;
        }
        public ResponseDataModel<CommentModel> GetById(long id)
        {
            ResponseDataModel<CommentModel> response = new();
            try
            {
                response.Data = _mapper.Map<CommentModel>(_context.TbComments.Find(id));
                response.Success = true;
                response.Message = String.Format(Messages.SuccessMessage, "Comment retrived");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = true;
            }
            return response;
        }

        public ResponseListModel<CommentModel> GetAllByBlogId(long id, bool showAllComments)
        {
            ResponseListModel<CommentModel> response = new();
            try
            {
                var commentQuery = _context.TbComments.Where(comment => comment.IsActive == true && comment.BlogId == id);
                response.TotalItems = commentQuery.Count();
                if (!showAllComments)
                    commentQuery = commentQuery.Take(5);
                List<TbComment> tbComments = commentQuery.Include(comment => comment.CreatedByNavigation).ToList();
                List<CommentModel> comments = new();

                foreach (TbComment tbComment in tbComments)
                {
                    CommentModel comment = _mapper.Map<CommentModel>(tbComment);
                    if (tbComment.CreatedBy != null)
                    {
                        comment.User = _mapper.Map<UserModel>(tbComment.CreatedByNavigation);
                        comment.User.Password = null;
                        comment.User.Avatar = _imageExtension.GetImage(tbComment.CreatedByNavigation);
                    }
                    comments.Add(comment);
                }

                response.Items = comments;
                response.Success = true;
                response.Message = String.Format(Messages.SuccessMessage, "Comments retrived");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ResponseModel> Create(CommentModel comment)
        {
            ResponseModel response = new();
            try
            {
                TbComment tbComment = _mapper.Map<TbComment>(comment);
                _context.TbComments.Add(tbComment);
                _context.SaveChanges();

                NotificationModel notifModel = new();

                string notifMessage = String.Empty;
                
                if(comment.CreatedBy != null)
                {
                    notifMessage = _context.TbUsers.Find(comment.CreatedBy).Name + " commented on your post: " + _context.TbBlogs.Find(comment.BlogId).Title;
                }
                else
                {
                    notifMessage = comment.Name + " commented on your post: " + _context.TbBlogs.Find(comment.BlogId).Title;
                }

                notifModel.NotificationMessage = notifMessage;

               //await _notify.Clients.All.BroadcastMessage(notifModel);

                response.Message = String.Format(Messages.NewItemMessage, "Comment");
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
