using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Controllers.Resources;
using PeopleSearch.Models;
using PeopleSearch.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleSearchDbContext context;
        private readonly IMapper mapper;

        public PeopleController(PeopleSearchDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/people")]
        public async Task<IEnumerable<PersonResource>> GetPeople()
        {
            List<Person> peeps = await context.People
                .Include(p => p.Interests)
                .Include(p => p.Address)
                .ToListAsync();

            return mapper.Map<List<Person>, List<PersonResource>>(peeps);
        }
    }
}
