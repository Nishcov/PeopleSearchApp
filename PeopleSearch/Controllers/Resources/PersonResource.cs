using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers.Resources
{
    public class PersonResource
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressResource Address { get; set; }

        public int Age { get; set; }

        public string Interests { get; set; }

        public string PhotoFileName { get; set; }
    }
}
