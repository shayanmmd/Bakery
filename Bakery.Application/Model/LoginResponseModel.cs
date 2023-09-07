namespace Bakery.Application.Models
{
    public class LoginResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string refreshToken { get; set; }
        public string ErrorMessage { get; set; }
    }
}