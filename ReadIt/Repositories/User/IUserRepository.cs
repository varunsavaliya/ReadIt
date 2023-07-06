using ReadIt.ViewModels;

namespace ReadIt.Repositories.User
{
    public interface IUserRepository
    {
        public ResponseDataModel<UserModel> GetUserById(long id);
        public ResponseModel EditUser(long id, UserModel user);

    }
}
