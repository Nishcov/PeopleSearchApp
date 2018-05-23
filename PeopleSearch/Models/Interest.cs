using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    public class Interest
    {
        public int Id { get; set; }

        public string Activity { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }
    }
}
