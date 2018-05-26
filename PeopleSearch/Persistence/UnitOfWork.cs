using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeopleSearchDbContext context;

        public UnitOfWork(PeopleSearchDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
