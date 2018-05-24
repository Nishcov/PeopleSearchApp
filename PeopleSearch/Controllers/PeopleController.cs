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
    [Route("/api/people")]
    public class PeopleController : Controller
    {
        private readonly PeopleSearchDbContext context;
        private readonly IMapper mapper;

        public PeopleController(PeopleSearchDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonResource>> GetPeople()
        {
            List<Person> peeps = await context.People
                .Include(p => p.Interests)
                .Include(p => p.Address)
                .ToListAsync();

            return mapper.Map<List<Person>, List<PersonResource>>(peeps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            Person person = await context.People
                .Include(p => p.Interests)
                .Include(p => p.Address)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            PersonResource personResource = mapper.Map<Person, PersonResource>(person);

            return Ok(personResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonResource personResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = mapper.Map<PersonResource, Person>(personResource);

            context.People.Add(person);
            await context.SaveChangesAsync();

            PersonResource resourceResult = mapper.Map<Person, PersonResource>(person);

            return Ok(resourceResult);
        }
    }
}
