namespace ReadIt.ViewModels
{
    public class CommentModel
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public long BlogId { get; set; }

        public long CreatedBy { get; set; }
    }
}
