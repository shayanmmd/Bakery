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

namespace Bakery.Persistence.Services
{
    public class JwtManager : IJwtManager
    {
        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
    {
        { "s","s"},
        { "user2","password2"},
        { "user3","password3"},
    };

        private readonly IConfiguration _iconfiguration;


        public JwtManager(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;

        }
        public Tokens Authenticate(Users users)
        {
            if (!UsersRecords.Any(x => x.Key == users.UserName && x.Value == users.PhoneNumber))
            {
                return null;
            }


            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, users.UserName),
                     new Claim(ClaimTypes.Role,Enums.RoleOfUsers.Admin.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
            
        }
    }
}
