using ReadIt.Models;

namespace ReadIt.Extentions.ImageExtention
{
    public class ImageExtension<T> : IImageExtension<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public ImageExtension(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteImages(long id)
        {
            var entityType = typeof(T).Name;
            string mediaName = null;
            object existingMedia = null;
            var folder = "Blog Images";
            string oldMediaPath = null;
            if (entityType == "TbBlog")
            {
                existingMedia = _context.TbBlogMedia.FirstOrDefault(media => media.BlogId == id);
                if (existingMedia != null)
                    mediaName = (existingMedia as TbBlogMedium).MediaPath;
            }
            else if (entityType == "TbUser")
            {
                folder = "Profile Images";
                existingMedia = _context.TbUsers.Find(id);
                mediaName = (existingMedia as TbUser).Avatar;
            }
            if (existingMedia != null && mediaName != null)
            {
                oldMediaPath = Path.Combine(Directory.GetCurrentDirectory(), "Media", folder, mediaName);
            }
            // delete the previous images from the server's directory
            if (oldMediaPath != null)
            {
                foreach (var file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Media", folder)))
                {
                    if (oldMediaPath.Contains(file))
                    {
                        System.IO.File.Delete(file);
                    }
                }
                if (entityType == "TbBlog")
                {
                    _context.RemoveRange(existingMedia);
                }
                else if (entityType == "TbUser")
                {
                    (existingMedia as TbUser).Avatar = null;
                }
                _context.SaveChanges();
            }
        }

        public void AddImages(IFormFile file, T tbEntity)
        {
            var folder = "Blog Images";
            string fileName = null;
            var entityType = typeof(T).Name;
            if (entityType == "TbBlog")
            {
                fileName = "Blog_Image_" + (tbEntity as TbBlog).Id + Path.GetExtension(file.FileName);
            }
            else if (entityType == "TbUser")
            {
                folder = "Profile Images";
                fileName = "Profile_Image_" + (tbEntity as TbUser).Id + Path.GetExtension(file.FileName);
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", folder, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            if (entityType == "TbBlog")
            {
                TbBlogMedium media = new();
                media.BlogId = (tbEntity as TbBlog).Id;
                media.MediaPath = fileName;

                _context.TbBlogMedia.Add(media);
            }
            else if (entityType == "TbUser")
            {
                (tbEntity as TbUser).Avatar = fileName;
            }
            _context.SaveChanges();
        }

        public string GetImage(T tbEntity)
        {
            string image = null;
            var entityType = typeof(T).Name;
            if (entityType == "TbBlog")
            {
                var media = _context.TbBlogMedia
                .Where(m => m.BlogId == (tbEntity as TbBlog).Id)
                .FirstOrDefault();

                if (media != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Blog Images", media.MediaPath);
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string base64String = Convert.ToBase64String(fileBytes);
                    image = base64String;
                }
            }
            else if (entityType == "TbUser")
            {
                if ((tbEntity as TbUser).Avatar != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Profile Images", (tbEntity as TbUser).Avatar);
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string base64String = Convert.ToBase64String(fileBytes);
                    image = base64String;
                }
            }

            return image;
        }
    }
}
