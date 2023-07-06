namespace ReadIt.ViewModels
{
    public class CommentModel
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public long BlogId { get; set; }

        public long? CreatedBy { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public UserModel User { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
