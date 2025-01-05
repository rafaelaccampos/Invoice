namespace Invoice.Domain;

public class Invoice(DateTime date, decimal amount)
{
    public DateTime Date { get; } = date;

    public decimal Amount { get; } = amount;
}
