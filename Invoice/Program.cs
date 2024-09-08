using FluentMigrator.Runner;
using Invoice.Data.Migrations;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb =>
        rb.AddSqlServer()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Invoice"))
        .ScanIn(typeof(AddTables).Assembly).For.Migrations()
    );

var scope = app.Services.CreateScope();
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
};

app.Run();

public partial class Program { }