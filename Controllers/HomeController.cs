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
            if (model.Id == 0)
            {
                //Create
                _context.Expenses.Add(model);

            }
            else
            {
                //Editing
                _context.Expenses.Update(model);
            }


            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }
        
        public IActionResult Delete(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();


            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if(id != null)
            {
                var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);

                return View(expenseInDb);
            }

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
