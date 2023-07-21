namespace ReadIt.Core.ViewModels.Common
{
    public class ResponseDataModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
