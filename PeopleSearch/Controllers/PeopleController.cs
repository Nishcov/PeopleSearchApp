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
        private readonly IMapper mapper;
        private readonly IPersonRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PeopleController(IMapper mapper, IPersonRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonResource>> GetPeople()
        {
            return await repository.GetPeople();
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

            repository.Add(person);
            await unitOfWork.CompleteAsync();

            person = await repository.GetPerson(person.Id);

            PersonResource resourceResult = mapper.Map<Person, PersonResource>(person);

            return Ok(resourceResult);
        }
    }
}
