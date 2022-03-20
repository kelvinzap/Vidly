using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

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
            return Content("Id=" + id);
        }

        //movies
        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(c => c.Genre)
                .ToList();

            return View(movies);
        }

    }
}