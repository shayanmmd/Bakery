using Bakery.Application.Models;

namespace Bakery.Application.Contracts.Identity
{
    public interface IJwtManager
    {
        Tokens Authenticate(string phoneNumber);
    }
}
