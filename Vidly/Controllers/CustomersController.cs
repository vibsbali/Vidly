using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = model.Customer;
                if (model.Customer.Id == 0)
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    var customerFromDb = context.Customers.Single(c => c.Id == customer.Id);
                    customerFromDb.Name = customer.Name;
                    customerFromDb.DateOfBirth = customer.DateOfBirth;
                    customerFromDb.MembershipTypeId = customer.MembershipTypeId;
                    customerFromDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                }
                context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }

            model.MembershipTypes = context.MembershipTypes.ToList();
            return View("CustomerForm", model);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var vm = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };

            return View("CustomerForm", vm);
        }
    }
}