using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Abstract;
using UserProcess.Entity.Concrete;
using UserProcess.Entity.Dtos;
using UserProcess.Services.Abstract;
using UserProcess.Shared.Helpers;

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
                person.Address.ModifiedDate = DateTime.Now;
                person.Address.ModifiedByName = "Admin";
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

        public async Task<List<PersonGetDto>> GetAll(string filter)
        {
            var personDatas=await _unitOfWork.Person.GetAllAsync(x=>x.IsActive==true, x=>x.Address);
            var returnedPersondatas=_mapper.Map<List<PersonGetDto>>(personDatas);

          
            if (!(string.IsNullOrWhiteSpace(filter)))
            {
                var filteredParams = JsonConvert.DeserializeObject<PersonGetDto>(filter, new CustomJsonConvertor(typeof(PersonGetDto)));
                if (!(string.IsNullOrEmpty(filteredParams.FirstName)))
                    returnedPersondatas = returnedPersondatas.Where(x => x.FirstName == filteredParams.FirstName).ToList();
                if (!(string.IsNullOrEmpty(filteredParams.LastName)))
                    returnedPersondatas = returnedPersondatas.Where(x => x.LastName == filteredParams.LastName).ToList();
                if (!(string.IsNullOrEmpty(filteredParams.City)))
                    returnedPersondatas = returnedPersondatas.Where(x => x.City == filteredParams.City).ToList();
              
            }
           
            return returnedPersondatas;
        }
    }
}
