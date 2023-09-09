using Bakery.Application.Contracts.Identity;
using Bakery.Application.Models;
using Bakery.Persistence.DbContexts;
using Bakery.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Bakery.Application.Contracts.Persistence;

namespace Bakery.Persistence.Services
{
    public class JwtManager : IJwtManager
    {
        private readonly IConfiguration _iconfiguration;
        private readonly IUserRepository _userRepository;

        public JwtManager(IConfiguration iconfiguration, IUserRepository userRepository)
        {
            _iconfiguration = iconfiguration;
            _userRepository = userRepository;
        }
        public Tokens Authenticate(string phoneNumber)
        {
            var user = _userRepository.FindByPhoneNumber(phoneNumber);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Role,((Enums.RoleOfUsers)user.Role).ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}
