﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_BowlersList.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers.Include(x => x.Team);
        public void AddBowler (Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }
        public void UpdateBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }
        public void RemoveBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
