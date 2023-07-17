
using AutoMapper;
using ReadIt.Entities.Models;
using ReadIt.Entities.ViewModels;

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
        }
    }
}
