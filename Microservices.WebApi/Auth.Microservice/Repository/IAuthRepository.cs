using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace Auth.Microservice.Repository
{
    public interface IAuthRepository
    {
        public AuthModel CheckLogin(string email, string password);
        public AuthModel SignUpUser(UserModel user);
        public ResponseModel ChangePassword(ChangePasswordModel model);

    }
}
