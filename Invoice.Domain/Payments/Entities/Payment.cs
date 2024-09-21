using Invoice.Domain.Contracts.Entities;

namespace Invoice.Domain.Payments.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }

        public Guid IdContract { get; private set; }

        public Contract Contract { get; private set; } = null!;

        public decimal Amount { get; private set; }

        public DateTime Date { get; private set; }
    }
}
