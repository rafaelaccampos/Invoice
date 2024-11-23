using Microsoft.Data.SqlClient;

namespace Invoice.IntegrationTests.Setup;

public static class DatabaseCreator
{
    public static void CreateDatabase(string connectionString)
    {
        var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
        var databaseName = connectionBuilder.InitialCatalog;

        var connectionStringMaster = new SqlConnectionStringBuilder(connectionBuilder.ConnectionString) { InitialCatalog = "master" }.ConnectionString;
        
        using var connection =  new SqlConnection(connectionStringMaster);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = $@"IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'{databaseName}')
                              CREATE DATABASE [{databaseName}]";
        command.ExecuteScalar();
    }
}
