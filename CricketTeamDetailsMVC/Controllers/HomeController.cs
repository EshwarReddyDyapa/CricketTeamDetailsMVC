using CricketTeamDetailsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CricketTeamDetailsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlayerDbContext playerDbContext;

        public HomeController(ILogger<HomeController> logger, PlayerDbContext playerDbContext)
        {
            _logger = logger;
            this.playerDbContext = playerDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AllPlayers()
        {
            //var result = playerDbContext.Players.FromSqlRaw("SelectAllPlayers").ToList();
            //var result = playerDbContext.Database.SqlQuery<SpResult>("").ToList();

            var result = playerDbContext.spResults.FromSqlRaw("SelectAllPlayers").ToList();

            return View(result);
        }
    }


}
