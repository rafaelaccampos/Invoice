using Invoice.Domain.Contracts.Entities;
using Invoice.Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data;

public class InvoiceContext(DbContextOptions<InvoiceContext> options) 
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceContext).Assembly);
    }

    public DbSet<Contract> Contracts { get; set; }

    public DbSet<Payment> Payments { get; set; }
}
