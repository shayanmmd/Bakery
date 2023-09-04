using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<BaseResponse> AddAsync(T item);
        Task<BaseResponse> UpdateAsync(T item);
        Task<BaseResponse> DeleteAsync(Guid guid);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid guid);
    }
}
