using AutoMapper;
using PeopleSearch.Controllers.Resources;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Address, AddressResource>();
            CreateMap<Interest, InterestResource>();
        }
    }
}
