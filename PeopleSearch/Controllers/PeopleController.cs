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
        private readonly IPersonRepository repository;

        public PeopleController(PeopleSearchDbContext context, IMapper mapper, IPersonRepository repository)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
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
            Person person = await repository.GetPerson(id);

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

            person = await repository.GetPerson(person.Id);

            PersonResource resourceResult = mapper.Map<Person, PersonResource>(person);

            return Ok(resourceResult);
        }
    }
}
