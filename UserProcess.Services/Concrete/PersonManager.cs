using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Abstract;
using UserProcess.Entity.Concrete;
using UserProcess.Entity.Dtos;
using UserProcess.Services.Abstract;

namespace UserProcess.Services.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<long> Add(PersonAddDto entity, string userName)
        {
            var person = _mapper.Map<Person>(entity);
            Person addedPerson=new Person();
            if (entity.Id == 0)
            {
                person.CreatedDate = DateTime.Now;
                person.CreatedByName = userName;
                person.IsActive = true;
                addedPerson=await _unitOfWork.Person.AddAsync(person);
            }
            else
            {
                person.ModifiedDate = DateTime.Now;
                person.ModifiedByName = userName;
                person.IsActive = true;
                addedPerson =await _unitOfWork.Person.UpdateAsync(person);
            }
            await _unitOfWork.SaveAsync();

            return addedPerson.Id;
        }

        public Task<long> Delete(int personId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<PersonGetDto> Get(int personId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PersonGetDto>> GetAll()
        {

            var personDatas=await _unitOfWork.Person.GetAllAsync(x=>x.IsActive==true, x=>x.Address);
            var returnedPersondatas=_mapper.Map<IList<PersonGetDto>>(personDatas);
            return returnedPersondatas;
        }
    }
}
