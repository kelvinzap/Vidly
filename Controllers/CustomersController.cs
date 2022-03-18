using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // customers
        public ActionResult Index()
        {
            var customers = GetCustomers();


            return View(customers);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer(){Id = 1, Name = "John Smith"},
                new Customer(){Id = 2, Name = "Mary Williamo"}
            };
        }

        //customer/details
        [HttpGet]
        public ActionResult Details(int Id)
        {
            if (Id == 0)
                return HttpNotFound();

            var customer = GetCustomers().SingleOrDefault(p => p.Id == Id);


            return View(customer);
        }
    }
}