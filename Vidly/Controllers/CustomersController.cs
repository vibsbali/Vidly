using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Smith"},
            new Customer {Id = 2, Name = "Mary Williams"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = Customers.Find(c => c.Id == id);
            return View(customer);
        }
    }
}