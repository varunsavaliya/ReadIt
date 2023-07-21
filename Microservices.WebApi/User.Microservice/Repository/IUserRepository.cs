
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;

namespace User.Microservice.Repository
{
    public interface IUserRepository
    {
        public ResponseDataModel<UserModel> GetUserById(long id);
        public ResponseModel EditUser(long id, UserModel user);

    }
}
