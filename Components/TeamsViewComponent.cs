using Microsoft.AspNetCore.Mvc;
using Mission13_BowlersList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_BowlersList.Components
{
    public class TeamsViewComponent: ViewComponent
    {
        private ITeamsRepository repo { get; set; }
        public TeamsViewComponent (ITeamsRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["TeamName"];
            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);
            return View(teams);
        }
    }
}
