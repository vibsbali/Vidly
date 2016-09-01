using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext context;
        public MoviesController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Id = 1,
                Name = "Shrek!"
            };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int movieId)
        {
            return Content("Id = " + movieId);
        }

        public ActionResult Details(int id)
        {
            var movie = context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        //Created Attribute based route. We can also contraint using following min, max, minlength, maxlength, int, float, guid
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}