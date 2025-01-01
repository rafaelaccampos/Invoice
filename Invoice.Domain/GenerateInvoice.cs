namespace Invoice.Domain;

public class GenerateInvoice(IContractRepository contractRepository)
{
    private readonly IContractRepository _contractRepository = contractRepository;

    public async Task<IList<InvoiceOutput>> Execute(ContractInput contractInput)
    {
        var contracts = await _contractRepository.List();
        IList<InvoiceOutput> invoicesOutput = [];

        foreach(var contract in contracts)
        {
            if(contractInput.Type == "cash")
            {
                foreach (var payment in contract.Payments)
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
