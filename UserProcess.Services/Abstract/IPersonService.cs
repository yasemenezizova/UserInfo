using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Entity.Dtos;
using UserProcess.Shared.Services.Abstract;

namespace UserProcess.Services.Abstract
{
    public interface IPersonService 
    {
        Task<PersonGetDto> Get(int personId);
        Task<List<PersonGetDto>> GetAll(string filter);
        Task<long> Add(PersonAddDto entity, string userName);
        Task<long> Delete(int personId, string modifiedByName);
    }
}
