using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BudgetApp.Models;

namespace BudgetApp.Data {
    public class BudgetQueries {
        private readonly DapperContext _context;

        public BudgetQueries(DapperContext context)
        {
            _context = context;
        }

        public void InsertBudget(BudgetInfo budget)
        {
            using var connection = _context.CreateConnection();

            string sql = @"
                INSERT INTO BudgetInfo (AccountTotal,CurrentMonth,MonthlyIncome,DateChecked)
                VALUES (@AccountTotal, @CurrentMonth,@MonthlyIncome,@DateChecked);
                SELECT SCOPE_IDENTITY();";

            connection.Query(sql, budget);
        }

        public List<BudgetInfo> GetBudgetInfo(string month)
        {
            using var connection = _context.CreateConnection();

            string sql = @"SELECT * FROM BudgetInfo WHERE CurrentMonth = @month";

            // Returns the result of the query 
            // Month = month is making sure that the SQL uses the parameter month. 
            return connection.Query<BudgetInfo>(sql, new { Month = month }).ToList();
        }

       

    }
}
