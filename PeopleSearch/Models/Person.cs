using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public int Age { get; set; }

        public ICollection<Interest> Interests { get; set; }

        public Person()
        {
            Interests = new Collection<Interest>();
        }
    }
}
