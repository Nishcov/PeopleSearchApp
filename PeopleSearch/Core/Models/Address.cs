using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    [Table("Addresses")]
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(255)]
        public string Locality { get; set; }

        [Required]
        [StringLength(255)]
        public string Province { get; set; }

        [Required]
        [StringLength(255)]
        public int PostCode { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }
    }
}
