using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies_List.Models;

namespace Movies_List.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieFormContext filmContext { get; set; }

        public HomeController( MovieFormContext movieFilm)
        {
           
            filmContext = movieFilm;
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
           
            ViewBag.Categories = filmContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovieForm(NewMovieForm nmf)
        {
            if (ModelState.IsValid)
            {
                filmContext.Add(nmf);
                filmContext.SaveChanges();
                return View("confirmation", nmf);
            }
            else
            {
                ViewBag.Categories = filmContext.Categories.ToList();
                return View("AddMovieForm", nmf);

            }
           
            
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = filmContext.Response
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = filmContext.Categories.ToList();

            var movie = filmContext.Response.Single(x => x.MovieId == movieid);

            return View("AddMovieForm", movie);
        }
        [HttpPost]
        public IActionResult Edit(NewMovieForm mf)
        {
            filmContext.Update(mf);
            filmContext.SaveChanges();
            return RedirectToAction("Movielist");
        }



        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = filmContext.Response.Single(x => x.MovieId == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(NewMovieForm mf)
        {
            filmContext.Response.Remove(mf);
            filmContext.SaveChanges();
            return RedirectToAction("Movielist");
        }
    }
}
