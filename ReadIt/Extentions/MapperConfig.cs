using AutoMapper;
using ReadIt.Models;
using ReadIt.ViewModels;

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
