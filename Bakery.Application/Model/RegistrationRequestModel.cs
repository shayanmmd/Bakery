using System.Text.Json.Serialization;
using Shared.Enums;

namespace Bakery.Application.Models
{
    public class RegistrationRequestModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
}