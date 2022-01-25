using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies_List.Models;

namespace Movies_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieFormContext filmContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieFormContext movieFilm)
        {
            _logger = logger;
            //filmContext = movieFilm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovieForm(NewMovieForm nmf)
        {
            filmContext.Add(nmf);
            filmContext.SaveChanges();
            return View("confirmation", nmf);
            
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
