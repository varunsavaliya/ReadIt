using ReadIt.Models;

namespace ReadIt.Extentions.ImageExtention
{
    public interface IImageExtension<T> where T : class
    {
        public void DeleteImages(long id);
        public void AddImages(IFormFile file, T tbEntity);
        public string GetImage(T tbEntity);

    }
}
