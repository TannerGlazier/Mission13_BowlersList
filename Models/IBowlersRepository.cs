using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_BowlersList.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        public void AddBowler(Bowler bowler);
        public void UpdateBowler(Bowler bowler);
        public void RemoveBowler(Bowler bowler);
    }
}
