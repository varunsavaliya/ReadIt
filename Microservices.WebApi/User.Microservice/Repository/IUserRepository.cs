
using ReadIt.Entities.ViewModels;
using ReadIt.Entities.ViewModels.Common;

namespace User.Microservice.Repository
{
    public interface IUserRepository
    {
        public ResponseDataModel<UserModel> GetUserById(long id);
        public ResponseModel EditUser(long id, UserModel user);

    }
}
