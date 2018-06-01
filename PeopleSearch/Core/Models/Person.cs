using PeopleSearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    [Table("People")]
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public Address Address { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(255)]
        public string Interests { get; set; }

        public Photo Photo { get; set; }
    }
}
