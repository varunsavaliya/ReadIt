using Microsoft.AspNetCore.Http;
using ReadIt.Core.ViewModels.Common;

namespace ReadIt.Core.ViewModels
{
    public class BlogModel: BaseModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public long CreatedBy { get; set; }
        public UserModel User { get; set; }
        public int TotalComments { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IFormFile? BlogImage { get; set; }
        public string BlogImageUrl { get; set; }
    }
}
