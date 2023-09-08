using System.Threading.Tasks;
using Bakery.Application.Models;

namespace Bakery.Application.Contracts.Sms
{
    public interface ISmsService
    {
        Task<SmsResposne> ConfirmCodeBySmsAsync(string phoneNumber);
    }
}