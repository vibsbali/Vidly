using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Id = 1,
                Name = "Shrek!"
            };

            //var customers = new List<Customer>
            //{
            //    new Customer {Name = "John Smith"},
            //    new Customer {Name = "Mary Williams"}
            //};

            //var viewModel = new RandomMovieViewModel
            //{
            //    Customers = customers,
            //    Movie = movie
            //};

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        public ActionResult Index(int pageIndex = 1, string sortBy = "Name")
        {
            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        //Created Attribute based route. We can also contraint using following min, max, minlength, maxlength, int, float, guid
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}