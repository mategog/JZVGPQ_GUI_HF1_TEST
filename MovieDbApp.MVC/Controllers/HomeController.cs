using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieDbApp.Logic;
using MovieDbApp.Models;
using MovieDbApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieLogic logic;
        public HomeController(ILogger<HomeController> logger, IMovieLogic logic)
        {
            _logger = logger;
            this.logic = logic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListMovie()
        {
            return View(this.logic.ReadAll());
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            this.logic.Create(movie);
            return RedirectToAction(nameof(ListMovie));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
