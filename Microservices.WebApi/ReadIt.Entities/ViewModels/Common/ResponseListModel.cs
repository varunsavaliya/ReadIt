namespace ReadIt.Core.ViewModels.Common
{
    public class ResponseListModel<T> : ResponseModel
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
    }
}
