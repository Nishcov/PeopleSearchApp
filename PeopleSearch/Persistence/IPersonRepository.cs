using PeopleSearch.Controllers.Resources;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonResource>> GetPeople();

        Task<Person> GetPerson(int id);

        void Add(Person person);
    }
}
