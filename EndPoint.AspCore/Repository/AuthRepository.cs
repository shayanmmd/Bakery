using Bakery.Application.Models;
using EndPoint.AspCore.Contracts;
using Newtonsoft.Json;
using Shared.Responses;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EndPoint.AspCore.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<BaseResponse> RegisterAsync(RegistrationRequestModel registrationRequestModel)
        {
            var client = _clientFactory.CreateClient("Client");
            var jsonBody = JsonConvert.SerializeObject(registrationRequestModel);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("/Auth/Register", content);
            var response = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponse>(response);
        }

        public async Task<LoginModel> LoginFirstStepAsync(string phoneNumber)
        {
            var client = _clientFactory.CreateClient("Client");
            var url = client.BaseAddress + "/Auth/LoginFirstStep";
            using var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
            request.Headers.Add("phoneNumber", phoneNumber);
            var res = await client.SendAsync(request);
            var response = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginModel>(response);
        }

        public async Task<LoginModel> LoginSecondStepAsync(string phoneNumber)
        {
            var client = _clientFactory.CreateClient("Client");
            var url = client.BaseAddress + "/Auth/LoginSecondStep";
            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("phoneNumber", phoneNumber);
            var res = await client.SendAsync(request);
            var response = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginModel>(response);
        }
    }
}