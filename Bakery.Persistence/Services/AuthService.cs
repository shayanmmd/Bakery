using System;
using System.Threading.Tasks;
using Bakery.Application.Contracts.Identity;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Models;
using Bakery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using System.Linq;
using Bakery.Application.Contracts.Sms;
using MediatR;
using MelyPayamak;
using Shared.Enums;
using Shared.SMS;

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
        public async Task<LoginModel> LoginFirstStepAsync(string phoneNumber)
        {
            try
            {
                var user = _userRepository.FindByPhoneNumber(phoneNumber);
                if (user == null)
                    return new LoginModel()
                    {
                        IsSuccess = false,
                        ErrorMessage = "کاربر یافت نشد باید در ابتدا ثبت نام کنید"
                    };
                return new LoginModel { IsSuccess = true, PhoneNumber = phoneNumber };
            }
            catch
            {
                return new LoginModel() { IsSuccess = false, ErrorMessage = "خظای غیر منتظره ای رخ داده است در صورت تلاش چند باره مجدد و دریافت دوباره همین خطا با پشتیبانی تماس بگیرید" };
            }
        }

        public async Task<LoginModel> LoginSecondStepAsync(string phoneNumber)
        {
            try
            {
                var tokens = _jwtManager.Authenticate(phoneNumber);
                if (tokens == null)
                    return new LoginModel()
                    {
                        IsSuccess = false,
                        ErrorMessage = "کاربری با این شماره همراه یافت نشد"
                    };
                return new LoginModel()
                {
                    IsSuccess = true,
                    Token = tokens.Token
                };
            }
            catch
            {
                return new LoginModel()
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
                    Role =(short)Enums.RoleOfUsers.Customer,
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