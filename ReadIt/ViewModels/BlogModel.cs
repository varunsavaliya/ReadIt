namespace ReadIt.ViewModels
{
    public class BlogModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public long CreatedBy { get; set; }
        public UserModel User { get; set; }
        public List<CommentModel> Comments { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public IFormFile? BlogImage { get; set; }
        public string BlogImageUrl { get; set; }
    }
}
