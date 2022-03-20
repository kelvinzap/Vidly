using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }


        //customer/details
        [HttpGet]
        public ActionResult Details(int Id)
        {
            if (Id == 0)
                return HttpNotFound();

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(p => p.Id == Id);


            return View(customer);
        }
    }
}