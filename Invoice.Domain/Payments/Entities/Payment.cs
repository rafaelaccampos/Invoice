using Invoice.Domain.Contracts.Entities;

namespace Invoice.Domain.Payments.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Contract Contract { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
