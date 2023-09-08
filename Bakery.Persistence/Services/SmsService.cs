using System;
using System.Text;
using System.Threading.Tasks;
using Bakery.Application.Contracts.Sms;
using Bakery.Application.Models;
using MelyPayamak;
using Shared.SMS;

namespace Bakery.Persistence.Services
{
    public class SmsService : ISmsService
    {
        public async Task<SmsResposne> ConfirmCodeBySmsAsync(string phoneNumber)
        {
            try
            {
                var codeToConfirm = MessageGenerator();
                var sms = new SendSoapClient(SendSoapClient.EndpointConfiguration.SendSoap);
                var resFromSms = await sms.SendSimpleSMS2Async(SmsSettings.UserName
                    , SmsSettings.Password, phoneNumber, SmsSettings.From
                    , codeToConfirm, false);
                return new SmsResposne()
                {
                    ResponseOfMelyPayamak = resFromSms,
                    CodeToConfirm = codeToConfirm
                };
            }
            catch
            {
                return new SmsResposne()
                {
                    ErrorMessage = "خظای غیر منتظره ای رخ داده است در صورت تلاش چند باره مجدد و دریافت دوباره همین خطا با پشتیبانی تماس بگیرید"
                };
            }
        }

        private string MessageGenerator()
        {
            var codeToConfirm = new Random().Next(10000, 100000).ToString();
            StringBuilder message = new StringBuilder();
            message.AppendLine("کد پنج رقمی ورود شما به سایت:");
            message.AppendLine(codeToConfirm);
            return message.ToString();
        }
    }
}