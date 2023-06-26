namespace ReadIt.ViewModels
{
    public class AuthModel: ResponseDataModel<UserModel>
    {
        public string Token { get; set; }
    }
}
