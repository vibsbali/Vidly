using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "Shrek!"
            },
            new Movie
            {
                Id = 2,
                Name = "Wall-e"
            }
        };

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

        public ActionResult Index()
        {
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