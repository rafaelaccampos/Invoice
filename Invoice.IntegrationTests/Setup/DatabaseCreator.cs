using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace Invoice.IntegrationTests.Setup
{
    public static class DatabaseCreator
    {
        public static void CreateDatabase(string connectionString)
        {
            var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
        }
    }
}
