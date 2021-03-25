using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
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

        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]

        public IActionResult EnterMovie(EnterMovie movie)
        {
            if(ModelState.IsValid)
            {
                TempStorage.AddMovie(movie);
                return View("Confirmation", movie);
            }

            else
            {
                return View();
            }


           
        }

        public IActionResult MovieList()
        {
            return View(TempStorage.Movies);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult DeleteMovie(int MovieId)
        {
            IQueryable<EnterMovie> movies = _context.Movies.Where(x => x.MovieId == MovieId);
            
            foreach(EnterMovie m in movies)
            {
                _context.Remove(m);
            }
            _context.SaveChanges();

            return View("MovieList", _context.Movies);
            //return RedirectToAction("MovieList");
        }

        public IActionResult EditMovie(int MovieId)
        {
            IQueryable<EnterMovie> movies = _context.Movies.Where(x => x.MovieId == MovieId);

            foreach (EnterMovie m in movies)
            {
                _context.Remove(m);
            }
            _context.SaveChanges();
            return View("EditMovie", _context.Movies);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}