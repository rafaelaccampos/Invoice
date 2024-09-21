using Invoice.Domain.Payments.Entities;

namespace Invoice.Domain.Contracts.Entities
{
    public class Contract
    {
        public Guid Id { get; private set; }

        public string Description { get; private set; } = null!;

        public decimal Amount { get; private set; }

        public int Periods { get; private set; }

        public DateTime Date { get; private set; }

        public ICollection<Payment> Payments { get; private set; } = null!;
    }
}
