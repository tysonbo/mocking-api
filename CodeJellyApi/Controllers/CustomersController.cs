using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeJellyApi.Models;
using CodeJellyApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeJellyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly CodeJellyApiContext _context;

        public CustomersController(CodeJellyApiContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        [DisableCors]
        public List<Customer> GetCustomer()
        {
            List<Customer> customer = new List<Customer>();
            CustomerService customerService = new CustomerService();
            customer = customerService.GetAllCustomers();

            return customer;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        [DisableCors]
        public ActionResult GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Customer customer = new Customer();
            CustomerService customerService = new CustomerService();
            customer = customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        [DisableCors]
        public ActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerService customerService = new CustomerService();
            customerService.AddCustomer(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = new Customer();
            CustomerService customerService = new CustomerService();
            customer = customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            customerService.DeleteEntryFromDatabase(id);

            return Ok(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}