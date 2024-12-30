using FluentMigrator.Runner;
using Invoice.Data;
using Invoice.Data.Migrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<InvoiceContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Invoice")));

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb =>
        rb.AddSqlServer()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Invoice"))
        .ScanIn(typeof(AddTables).Assembly).For.Migrations()
    );

var app = builder.Build();

var scope = app.Services.CreateScope();
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
};

app.Run();

public partial class Program { }