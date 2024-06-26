﻿using AutoMapper;
using ReadIt.Core.Constants;
using ReadIt.Core.DataModels;
using ReadIt.Core.Extensions;
using ReadIt.Core.ViewModels;
using ReadIt.Core.ViewModels.Common;

namespace Auth.Microservice.Repository
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

        public AuthModel CheckLogin(string email, string password)
        {
            AuthModel response = new();

            try
            {
                List<TbUser> users = _context.TbUsers.ToList();

                TbUser validUser = users.FirstOrDefault(user1 =>
                    user1.Email.Equals(email) &&
                    user1.Password.Equals(password) && user1.IsActive == true);

                if (validUser != null)
                {
                    validUser.Password = null;
                    response.Data = _mapper.Map<UserModel>(validUser);
                    response.Token = JWTExtention.GetJwtToken(validUser, _configuration);
                    response.Success = true;
                    response.Message = AuthMessages.LogInMessage;
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
                if (_context.TbUsers.Any(user1 => user1.Email == user.Email && user1.IsActive == true))
                {
                    response.Success = false;
                    response.Message = "User already exists, please login";
                }
                else
                {

                    TbUser signupUser = _mapper.Map<TbUser>(user);

                    _context.TbUsers.Add(signupUser);
                    _context.SaveChanges();

                    TbUser validUser = _context.TbUsers.FirstOrDefault(validUser => validUser.Email.Equals(user.Email));

                    validUser.Password = null;
                    response.Data = _mapper.Map<UserModel>(validUser);
                    response.Token = JWTExtention.GetJwtToken(validUser, _configuration);
                    response.Success = true;
                    response.Message = AuthMessages.SignUpMessage;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public ResponseModel ChangePassword(ChangePasswordModel model)
        {
            ResponseModel response = new();
            try
            {
                TbUser tbUser = _context.TbUsers.Find(model.UserId);
                if (tbUser.Password == model.OldPassword)
                {
                    tbUser.Password = model.NewPassword;

                    _context.SaveChanges();

                    response.Success = true;
                    response.Message = "Password changed successfully";
                }
                else
                {
                    response.Message = "Enter correct old password";
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
    }
}
