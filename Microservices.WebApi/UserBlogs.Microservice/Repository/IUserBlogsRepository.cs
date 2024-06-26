﻿
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;

namespace UserBlogs.Microservice.Repository
{
    public interface IUserBlogsRepository
    {
        public ResponseListModel<BlogModel> GetAllByUserId(long userId);
        public ResponseModel Create(BlogModel blog);

        public ResponseModel Update(BlogModel blog, long id);

        public ResponseModel Delete(long id);
    }
}
