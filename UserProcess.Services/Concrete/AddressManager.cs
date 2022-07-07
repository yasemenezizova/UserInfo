using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Abstract;
using UserProcess.Entity.Dtos;
using UserProcess.Services.Abstract;

namespace UserProcess.Services.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<int> Add(AddressDto entity, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int addressId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> Get(int addresId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AddressDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
