using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Shared.Entities.Abstract;

namespace UserProcess.Shared.Services.Abstract
{
    public interface IBaseService<T> where T : class, IEntity
    {
        Task<T> Get(int articleId);
        Task<IQueryable<T>> GetAll();
        Task<int> Add(T entity, string createdByName);
        Task<int> Delete(int articleId, string modifiedByName);
        Task<int> HardDelete(int articleId);
    }
}
