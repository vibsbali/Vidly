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

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}