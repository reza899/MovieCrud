using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCrud.Data;
using MovieCrud.Models;

namespace MovieCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext context;
        private readonly ILogger<HomeController> logger;

        public HomeController(MovieDbContext context, ILogger<HomeController> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            var MovieList = context.Movies.ToList();
            return View(MovieList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            logger.LogInformation($"------ Name is {movie.Name} , Year {movie.Year}. ------");
            context.Movies.Add(movie);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
         [HttpGet]
        public IActionResult Detail(int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            context.Entry(movie).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}