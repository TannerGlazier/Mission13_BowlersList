using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13_BowlersList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_BowlersList.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repoBowler { get; set; }
        private ITeamsRepository _repoTeam { get; set; }
        public HomeController( IBowlersRepository b, ITeamsRepository t)
        {
            _repoBowler = b;
            _repoTeam = t;
        }

        public IActionResult Index(string teamName)
        {

            var bowlers = _repoBowler.Bowlers
                .Where(x => x.Team.TeamName == teamName || teamName == null);
            ViewBag.TeamName = teamName;
            ViewBag.NextBowler = _repoBowler.Bowlers.Max(x => x.BowlerID) + 1;
            return View(bowlers);
        }
        [HttpGet]
        public IActionResult AddBowler(int id)
        {
            Bowler b = new Bowler();
            b.BowlerID = id;
            ViewBag.Teams = _repoTeam.Teams.ToList();
            return View("Form", b);    
        }
        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repoBowler.AddBowler(b);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _repoTeam.Teams.ToList();

                return View("Form", b);
            }
        }
        [HttpGet]
        public IActionResult Edit (int Id)
        {
            
            Bowler bowler = _repoBowler.Bowlers.Single(x => x.BowlerID == Id);
            ViewBag.Teams = _repoTeam.Teams.ToList();
            ViewBag.Check = 1;
            return View("Form", bowler);
        }
        [HttpPost]
        public IActionResult Edit (Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repoBowler.UpdateBowler(b);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _repoTeam.Teams.ToList();
                ViewBag.Check = 1;
                return View("Form", b);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Bowler bowler = _repoBowler.Bowlers.FirstOrDefault(x => x.BowlerID == id);
            _repoBowler.RemoveBowler(bowler);
            return RedirectToAction("Index");
        }
    }
}
