using Invoice.Domain.Payments.Entities;

namespace Invoice.Domain.Contracts.Entities;

public class Contract(string description, decimal amount, int periods, DateTime date)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Description { get; private set; } = description;

    public decimal Amount { get; private set; } = amount;

    public int Periods { get; private set; } = periods;

    public DateTime Date { get; private set; } = date;

    public List<Payment> Payments { get; private set; } = [];

    public void AddPayments(List<Payment> payments)
    {
        Payments.AddRange(payments);
    }

    public IList<Invoice> GenerateInvoices(string type, int month, int year)
    {
        var invoices = new List<Invoice>();
        if (type == "cash")
        {
            foreach (var payment in Payments)
            {
                if (payment.Date.Month != month || payment.Date.Year != year)
                {
                    continue;
                }

                invoices.Add(new Invoice(payment.Date, payment.Amount));
            }
        }
        else
        {
            var period = 0;
            while (period <= Periods)
            {
                var date = Date.AddMonths(period++);

                if (date.Month != month || date.Year != year)
                {
                    continue;
                }
                var amount = Amount / Periods;
                invoices.Add(new Invoice(date, amount));
            }
        }

        return invoices;
    }
}
