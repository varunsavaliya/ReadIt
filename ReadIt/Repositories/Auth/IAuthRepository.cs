using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.Auth
{
    public interface IAuthRepository
    {
        public AuthModel CheckLogin(UserModel user);
        public AuthModel SignUpUser(UserModel user);
        public ResponseModel ChangePassword(ChangePasswordModel model);

    }
}
