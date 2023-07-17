using ReadIt.Entities.ViewModels.Common;

namespace ReadIt.Entities.ViewModels
{
    public class AuthModel: ResponseDataModel<UserModel>
    {
        public string Token { get; set; }
    }
}
