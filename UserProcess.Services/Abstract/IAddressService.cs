using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Entity.Dtos;
using UserProcess.Shared.Services.Abstract;

namespace UserProcess.Services.Abstract
{
    public interface IAddressService 
    {
        Task<AddressDto> Get(int addresId);
        Task<IQueryable<AddressDto>> GetAll();
        Task<int> Add(AddressDto entity, string createdByName);
        Task<int> Delete(int addressId, string modifiedByName);
    }
}
