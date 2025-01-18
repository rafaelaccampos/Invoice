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
            var invoices = contract.GenerateInvoices(contractInput.Type, contractInput.Month, contractInput.Year);

            invoicesOutput = invoices.Select(invoice => new InvoiceOutput
            {
                Date = invoice.Date,
                Amount = invoice.Amount
            }).ToList();
        }

        return invoicesOutput;
    }
}
