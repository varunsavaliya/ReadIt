namespace ReadIt.ViewModels
{
    public class BlogModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public long CreatedBy { get; set; }

        public long CategoryId { get; set; }
        public IFormFile file { get; set; }
    }
}
