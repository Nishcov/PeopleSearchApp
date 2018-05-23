using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers.Resources
{
    public class AddressResource
    {
        public int Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Locality { get; set; }

        public string Province { get; set; }

        public int PostCode { get; set; }

        public string Country { get; set; }
    }
}
