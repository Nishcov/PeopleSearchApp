using AutoMapper;
using PeopleSearch.Controllers.Resources;
using PeopleSearch.Core.Models;
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
            CreateMap<Photo, PhotoResource>();

            // API Resource to Domain
            CreateMap<PersonResource, Person>()
                .ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<AddressResource, Address>()
                .ForMember(a => a.Id, opt => opt.Ignore());
            CreateMap<PhotoResource, Photo>()
                .ForMember(a => a.Id, opt => opt.Ignore());
        }
    }
}
