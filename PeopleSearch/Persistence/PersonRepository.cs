using Microsoft.EntityFrameworkCore;
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

        public PersonRepository(PeopleSearchDbContext context)
        {
            this.context = context;
        }

        public async Task<Person> GetPerson(int id)
        {
            return await context.People
                .Include(p => p.Interests)
                .Include(p => p.Address)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
