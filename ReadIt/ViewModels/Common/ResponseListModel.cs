namespace ReadIt.ViewModels
{
    public class ResponseListModel<T> : ResponseModel
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
    }
}
