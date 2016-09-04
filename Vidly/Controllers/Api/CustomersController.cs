using AutoMapper;
using System.Linq;
using System.Web.Http;
using Vidly.DTO;
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
            //Added mapping
            var customers = context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody]CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.Customers.Add(customer);
            context.SaveChanges();

            return Created($"/api/customers/{customer.Id}", customer);
        }

        [HttpPost]
        public IHttpActionResult UpdateCustomer(int id, [FromBody]CustomerDto customerDto)
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

            //This is where we have an existing prebuilt object
            Mapper.Map(customerDto, customerFromDb);
            //customerFromDb.Name = customerDto.Name;
            //customerFromDb.DateOfBirth = customerDto.DateOfBirth;
            //customerFromDb.MembershipTypeId = customerDto.MembershipTypeId;
            //customerFromDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;

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
