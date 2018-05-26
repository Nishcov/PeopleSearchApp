using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Controllers.Resources;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleSearchDbContext context;
        private readonly IMapper mapper;

        public PersonRepository(PeopleSearchDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<Person>> GetPeople()
        {
            return await context.People
                .Include(p => p.Interests)
                .Include(p => p.Address)
                .ToListAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            return await context.People
                .Include(p => p.Interests)
                .Include(p => p.Address)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Person person)
        {
            context.People.Add(person);
        }
    }
}
