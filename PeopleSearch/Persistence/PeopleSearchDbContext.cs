using Microsoft.EntityFrameworkCore;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence
{
    public class PeopleSearchDbContext : DbContext
    {
        public PeopleSearchDbContext(DbContextOptions<PeopleSearchDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
