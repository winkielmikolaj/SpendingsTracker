using Microsoft.AspNetCore.Mvc;
using SpendingsTracker.Models;
using System.Diagnostics;


namespace SpendingsTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpendingsTrackedDbContext _context;


        public HomeController(ILogger<HomeController> logger, SpendingsTrackedDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        public IActionResult CreateEditExpenseForm(Expense model)

        {
            _context.Expenses.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpense()
        {
            return View();
        }

        public IActionResult Expenses()
        { 
            var expenses = _context.Expenses.ToList();

            return View(expenses);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
