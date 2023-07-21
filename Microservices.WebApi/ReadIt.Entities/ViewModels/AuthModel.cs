using ReadIt.Core.ViewModels.Common;
using ReadIt.Core.ViewModels;

namespace ReadIt.Core.ViewModels
{
    public class AuthModel: ResponseDataModel<UserModel>
    {
        public string Token { get; set; }
    }
}
