using BudgetApp.Models;
using BudgetApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudgetApp.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly BudgetService _budgetService;

      
        public HomeController(ILogger<HomeController> logger, BudgetService budgetService)
        {
            _logger = logger;
            _budgetService = budgetService;
        }

        public IActionResult Index()
        {
            List<BudgetInfo> budgets = _budgetService.GetBudgets("March");
            return View(budgets);
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
