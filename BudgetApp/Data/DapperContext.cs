using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
namespace BudgetApp.Data {
    public class DapperContext {
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
