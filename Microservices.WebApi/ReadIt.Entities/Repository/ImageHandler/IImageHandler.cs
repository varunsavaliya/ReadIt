﻿using Microsoft.AspNetCore.Http;

namespace ReadIt.Extentions.ImageExtention
{
    public interface IImageHandler<T> where T : class
    {
        public void DeleteImages(long id);
        public void AddImages(IFormFile file, T tbEntity);
        public string GetImage(T tbEntity);

    }
}
