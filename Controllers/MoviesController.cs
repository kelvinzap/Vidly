using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //released
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        //Details
        public ActionResult Details(int Id)
        {
            if (Id == 0)
                return HttpNotFound();

            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);
            return View(movie);



        }
        //edit
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(p => p.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Id = movie.Id,
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);


        }

        //movies
        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(c => c.Genre)
                .ToList();

            return View(movies);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Id = 0,
                Genres = _context.Genres.ToList()
            };


            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.InStock = movie.InStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}