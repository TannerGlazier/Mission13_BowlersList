using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_BowlersList.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get; }
    }
}
