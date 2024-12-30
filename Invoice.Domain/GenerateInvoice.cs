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
            var payments = await _paymentRepository.GetPaymentsByContract(contract.Id);

            foreach(var payment in payments)
            {
                if(payment.Date.Month != contractInput.Month || payment.Date.Year != contractInput.Year)
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
        return invoicesOutput;
    }
}
