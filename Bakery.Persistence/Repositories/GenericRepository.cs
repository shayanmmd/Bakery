using Bakery.Application.Contracts.Persistence;
using Shared.Responses;
using Bakery.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MainDbContext _mainDbContext;

        public GenericRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<BaseResponse> AddAsync(T item)
        {
            var res = new BaseResponse();
            try
            {
                _mainDbContext.Add(item);
                _mainDbContext.SaveChanges();
            }
            catch (Exception ex) { res.AddException(ex); }
            return res;
        }

        public async Task<BaseResponse> DeleteAsync(Guid guid)
        {
            var res = new BaseResponse();
            try
            {
                var entity = GetAsync(guid);
                _mainDbContext.Remove(entity);
                _mainDbContext.SaveChanges();
            }
            catch (Exception ex) { res.AddException(ex); }
            return res;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _mainDbContext.Set<T>().ToList();
        }

        public async Task<T> GetAsync(Guid guid)
        {
            return _mainDbContext.Set<T>().SingleOrDefault();
        }

        public async Task<BaseResponse> UpdateAsync(T item)
        {
            var res = new BaseResponse();
            try
            {
                _mainDbContext.Update(item);
                _mainDbContext.SaveChanges();
            }
            catch (Exception ex) { res.AddException(ex); }
            return res;
        }
    }
}
