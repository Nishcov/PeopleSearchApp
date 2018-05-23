using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    [Table("Interests")]
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Activity { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }
    }
}
