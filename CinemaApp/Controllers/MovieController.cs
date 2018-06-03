using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFilm(MovieList movie)
        {
            if (ModelState.IsValid)
            {
                using (MovieDB db = new MovieDB())
                {
                    db.MovieList.Add(movie);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Movie successfully added";
            }
            return View();
        }
        public ActionResult MovieIndex()
        {
            using (MovieDB db = new MovieDB())
            {
                return View(db.MovieList.ToList());
            }
        }
    }
}