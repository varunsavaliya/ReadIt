using AutoMapper;
using ReadIt.Extentions;
using ReadIt.Models;
using ReadIt.ViewModels;

namespace ReadIt.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public AuthModel CheckLogin(UserModel user)
        {
            AuthModel response = new();

            try
            {
                List<TbUser> users = _context.TbUsers.ToList();

                TbUser validUser = users.FirstOrDefault(user1 =>
                    user1.Email.Equals(user.Email) &&
                    user1.Password.Equals(user.Password) && user1.IsActive == true);

                if (validUser != null)
                {
                    validUser.Password = null;
                    response.Data = _mapper.Map<UserModel>(validUser);
                    response.Token = JWTExtention.GetJwtToken(validUser, _configuration);
                    response.Success = true;
                    response.Message = "Login successfull!";
                }
                else
                {
                    response.Message = "Email or password is invalid";
                    response.Data = null;
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public AuthModel SignUpUser(UserModel user)
        {
            AuthModel response = new();

            try
            {
                TbUser signupUser = _mapper.Map<TbUser>(user);

                _context.TbUsers.Add(signupUser);
                _context.SaveChanges();

                TbUser validUser = _context.TbUsers.FirstOrDefault(validUser => validUser.Email.Equals(user.Email));

                validUser.Password = null;
                response.Data = _mapper.Map<UserModel>(validUser);
                response.Token = JWTExtention.GetJwtToken(validUser, _configuration);
                response.Success = true;
                response.Message = "Sign up successfull!";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
