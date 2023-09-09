using Bakery.Domain.Entities;

namespace Bakery.Application.Models
{
    public class LoginModel
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ErrorMessage { get; set; }
        public string PhoneNumber { get; set; }
    }
}