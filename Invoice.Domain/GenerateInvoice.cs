namespace Invoice.Domain;

public class GenerateInvoice(IContractRepository contractRepository, IPaymentRepository paymentRepository)
{
    private readonly IContractRepository _contractRepository = contractRepository;
    private readonly IPaymentRepository _paymentRepository = paymentRepository;

    public async Task<IList<InvoiceOutput>> Execute(ContractInput contractInput)
    {
        var contracts = await _contractRepository.List();
        IList<InvoiceOutput> invoicesOutput = [];

        foreach(var contract in contracts)
        {
            if(contractInput.Type == "cash")
            {
                var payments = await _paymentRepository.GetPaymentsByContract(contract.Id);

                foreach (var payment in payments)
                {
                    if (payment.Date.Month != contractInput.Month || payment.Date.Year != contractInput.Year)
                    {
                        continue;
                    }

                    invoicesOutput =
                    [
                        new() {
                        Date = payment.Date,
                        Amount = payment.Amount,
                        }
                    ];
                }
            }
            else
            {
                var period = 0;
                while(period <= contract.Periods)
                {
                    var date = contract.Date.AddMonths(period++);

                    if (date.Month != contractInput.Month || date.Year != contractInput.Year)
                    {
                        continue;
                    }
                    var amount = contract.Amount / contract.Periods;
                    invoicesOutput = 
                    [
                        new() {
                        Date = date,
                        Amount = amount,
                        }
                    ];
                }
            }
        }
        return invoicesOutput;
    }
}
