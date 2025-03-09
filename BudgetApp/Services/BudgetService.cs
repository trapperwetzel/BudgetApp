using BudgetApp.Data;
using BudgetApp.Models;
using System;

namespace BudgetApp.Services {
    public class BudgetService {

        private readonly BudgetQueries _budgetQueries;

        public BudgetService(BudgetQueries budgetQueries)
        {
            _budgetQueries = budgetQueries;
        }

        public void AddBudget(BudgetInfo budget)
        {
            _budgetQueries.InsertBudget(budget);
        }

        public List<BudgetInfo> GetBudgets(string month)
        {
            return _budgetQueries.GetBudgetInfo(month);
        }
    }
}
