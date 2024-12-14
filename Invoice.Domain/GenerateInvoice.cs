namespace Invoice.Domain;

public class GenerateInvoice
{
    private readonly IContractRepository _contractRepository;

    public GenerateInvoice(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }
    public async Task<IList<Output>> Execute(Input input)
    {
        var output = new List<Output>();
        var contracts = _contractRepository.List();

        if(input.Type == "cash")
        {
            foreach (var payment in contracts.Payments)
            {
                if(payment.Date.GetMonth() != input.Month || payment.date.GetFullYear() != input.Year {
                    continue;
                }

                output.push();
            }
        }
    }
}
