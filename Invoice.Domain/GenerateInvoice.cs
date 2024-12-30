namespace Invoice.Domain;

public class GenerateInvoice(IContractRepository contractRepository)
{
    private readonly IContractRepository _contractRepository = contractRepository;

    public async Task<IList<ContractOutput>> Execute(ContractInput contractInput)
    {
        var output = new List<ContractOutput>();
        var contracts = _contractRepository.List();

        if(contractInput.Type == "cash")
        {
            foreach (var payment in contracts.Payments)
            {
                if(payment.Date.GetMonth() != contractInput.Month || payment.date.GetFullYear() != contractInput.Year {
                    continue;
                }

                output.push();
            }
        }
    }
}
