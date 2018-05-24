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
            // Domain to API Resource
            CreateMap<Person, PersonResource>();
            CreateMap<Address, AddressResource>();
            CreateMap<Interest, InterestResource>();

            // API Resource to Domain
            CreateMap<PersonResource, Person>()
                .ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<AddressResource, Address>()
                .ForMember(a => a.Id, opt => opt.Ignore());
            CreateMap<InterestResource, Interest>()
                .ForMember(i => i.Id, opt => opt.Ignore());
        }
    }
}
