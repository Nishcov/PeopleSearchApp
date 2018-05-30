using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Controllers.Resources;
using PeopleSearch.Core;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers
{
    [Route("/api/people")]
    public class PeopleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPersonRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PeopleController(IMapper mapper, IPersonRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // Get full list of people from database
        [HttpGet]
        public async Task<List<PersonResource>> GetPeople()
        {
            List<Person> peeps = await repository.GetPeople();

            return mapper.Map<List<Person>, List<PersonResource>>(peeps);
        }
        
        // Get single person from database
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
        
        // Add a person to the database
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonResource personResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = mapper.Map<PersonResource, Person>(personResource);

            repository.Add(person);
            await unitOfWork.CompleteAsync();

            person = await repository.GetPerson(person.Id);

            PersonResource resourceResult = mapper.Map<Person, PersonResource>(person);

            return Ok(resourceResult);
        }
    }
}
