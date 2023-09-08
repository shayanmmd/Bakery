using System.Security.AccessControl;
using Microsoft.AspNetCore.Http.Features;

namespace Bakery.Application.Models
{
    public class SmsResposne
    {
        public string? CodeToConfirm { get; set; }
        public string? ResponseOfMelyPayamak { get; set; }
        public string? ErrorMessage { get; set; }
    }
}