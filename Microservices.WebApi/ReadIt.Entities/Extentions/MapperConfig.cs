
using AutoMapper;
using ReadIt.Core.DataModels;
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels;

namespace ReadIt.Extentions
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<TbUser, UserModel>().ReverseMap();
            CreateMap<TbCategory, CategoryModel>().ReverseMap();
            CreateMap<TbBlog, BlogModel>().ReverseMap();
            CreateMap<TbComment, CommentModel>().ReverseMap();
            CreateMap<TbNotification, NotificationModel>().ReverseMap();
        }
    }
}
