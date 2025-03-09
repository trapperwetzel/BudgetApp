using BudgetApp.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace BudgetApp.Models {
    public class BudgetInfo {

        public int Id { get; set; }
        public int AccountTotal { get; set; }
        public string? CurrentMonth { get; set; }
        public decimal MonthlyIncome { get; set; }

        public DateTime DateChecked { get; set; }

        
        public string GetInfo()
        {
            string message = $"Total: {AccountTotal}, Month: {CurrentMonth}, Income: {MonthlyIncome}, DateChecked: {DateChecked}";
            return message;
        }

        
    }
}
