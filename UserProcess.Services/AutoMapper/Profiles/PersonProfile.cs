using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Entity.Concrete;
using UserProcess.Entity.Dtos;

namespace UserProcess.Services.AutoMapper.Profiles
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonAddDto, Person>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<PersonGetDto, Person>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap().ForMember(dest=>dest.City, opt=>opt.MapFrom(x=>x.Address.City));
        }
    }
}
