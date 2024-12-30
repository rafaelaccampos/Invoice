using Invoice.Domain.Payments.Entities;

namespace Invoice.Domain.Contracts.Entities;

public class Contract(string description, decimal amount, int periods, DateTime date)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Description { get; private set; } = description;

    public decimal Amount { get; private set; } = amount;

    public int Periods { get; private set; } = periods;

    public DateTime Date { get; private set; } = date;

    public IList<Payment> Payments { get; private set; } = [];
}
