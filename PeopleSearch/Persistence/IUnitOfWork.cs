using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
