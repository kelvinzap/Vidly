using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {

            return Ok(_context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>));
        }


        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDB);


            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult RemoveCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                return NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }

    }
}
