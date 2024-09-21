using Invoice.Domain.Contracts.Entities;
using Invoice.Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options) { }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Payment> Payments { get; set; }

    }
}
