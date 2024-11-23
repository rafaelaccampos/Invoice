using Invoice.Domain.Contracts.Entities;

namespace Invoice.Domain.Payments.Entities;

public class Payment
{
    private Payment() { }

    public Payment(Contract contract, decimal amount) 
    {
        Id = Guid.NewGuid();
        Contract = contract;
        IdContract = contract.Id;
        Amount = amount;
        Date = DateTime.Now.Date;
    }

    public Guid Id { get; private set; }

    public Guid IdContract { get; private set; }

    public Contract Contract { get; private set; } = null!;

    public decimal Amount { get; private set; }

    public DateTime Date { get; private set; }
}