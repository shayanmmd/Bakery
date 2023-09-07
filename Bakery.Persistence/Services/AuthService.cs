using System;
using System.Threading.Tasks;
using Bakery.Application.Contracts.Identity;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Models;
using Bakery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using System.Linq;
using MediatR;

namespace Bakery.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtManager _jwtManager;

        public AuthService(IUserRepository userRepository, IJwtManager jwtManager)
        {
            _userRepository = userRepository;
            _jwtManager = jwtManager;
        }
        public LoginResponseModel Login(string phoneNumber)
        {
            try
            {
                var user = _userRepository.FindByPhoneNumber(phoneNumber);
                if (user == null)
                    return new LoginResponseModel() { IsSuccess = false, ErrorMessage = "کاربر یافت نشد باید در ابتدا ثبت نام کنید" };

                //TO DO SEND SMS

                var tokens = _jwtManager.Authenticate(new Users() { UserName = user.UserName, PhoneNumber = user.PhoneNumber });
                return new LoginResponseModel()
                {
                    IsSuccess = true,
                    Token = tokens.Token,
                    refreshToken = tokens.Token
                };
            }
            catch
            {
                return new LoginResponseModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "خظای غیر منتظره ای رخ داده است در صورت تلاش چند باره مجدد و دریافت دوباره همین خطا با پشتیبانی تماس بگیرید"
                };
            }
        }

        public async Task<BaseResponse> RegisterAsync(RegistrationRequestModel registrationRequestModel)
        {
            try
            {
                var user = new User()
                {
                    Guid = Guid.NewGuid(),
                    PhoneNumber = registrationRequestModel.PhoneNumber,
                    Role = (short)registrationRequestModel.Role,
                    SignedInDateTime = DateTime.Now,
                    Status = true,
                    UserName = registrationRequestModel.UserName
                };
                return await _userRepository.AddAsync(user);
            }
            catch
            {
                var ret = new BaseResponse();
                ret.AddError("خظای غیر منتظره ای رخ داده است در صورت تلاش چند باره مجدد و دریافت دوباره همین خطا با پشتیبانی تماس بگیرید");
                return ret;
            }

        }
    }
}