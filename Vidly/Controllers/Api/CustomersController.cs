using System.Linq;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers()
        {
            var customers = context.Customers.ToList();
            return Ok(customers);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Customers.Add(customer);
            context.SaveChanges();

            return Created($"/api/customers/{customer.Id}", customer);
        }

        [HttpPost]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerFromDb = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerFromDb == null)
            {
                return NotFound();
            }

            customerFromDb.Name = customer.Name;
            customerFromDb.DateOfBirth = customer.DateOfBirth;
            customerFromDb.MembershipTypeId = customer.MembershipTypeId;
            customerFromDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            context.SaveChanges();
            return Ok();
        }

        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerFromDb = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerFromDb == null)
            {
                return NotFound();
            }

            context.Customers.Remove(customerFromDb);
            context.SaveChanges();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
