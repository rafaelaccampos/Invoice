using Invoice.Domain.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data.Contracts.Repositories;

public class ContractRepository(InvoiceContext invoiceContext) : IContractRepository
{
    private readonly InvoiceContext _invoiceContext = invoiceContext;

    public async Task<IList<Contract>> List()
    {
        var contracts = await _invoiceContext.Contracts.ToListAsync();

        foreach (var contract in contracts) 
        {
            var payments = await _invoiceContext.Payments
                .Where(x => x.IdContract == contract.Id)
                .ToListAsync();
            contract.Payments.AddRange(payments);
        }
        return contracts;
    }
}
