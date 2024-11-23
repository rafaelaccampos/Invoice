using Invoice.Domain.Payments.Entities;

namespace Invoice.Domain.Contracts.Entities;

public class Contract
{
    public Contract(
        string description, 
        decimal amount,
        int periods)
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        Periods = periods;
        Date = DateTime.Now;
        Payments = new List<Payment>();
    }

    public Guid Id { get; private set; }

    public string Description { get; private set; } = null!;

    public decimal Amount { get; private set; }

    public int Periods { get; private set; }

    public DateTime Date { get; private set; }

    public ICollection<Payment> Payments { get; private set; } = null!;
}
