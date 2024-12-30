using Invoice.Domain.Payments.Entities;

namespace Invoice.Domain.Contracts.Entities;

public class Contract(string description, decimal amount, int periods)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Description { get; private set; } = description;

    public decimal Amount { get; private set; } = amount;

    public int Periods { get; private set; } = periods;

    public DateTime Date { get; private set; } = DateTime.Now;

    public IList<Payment> Payments { get; private set; } = [];
}
