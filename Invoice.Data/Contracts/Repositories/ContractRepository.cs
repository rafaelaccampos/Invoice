using Invoice.Domain.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data.Contracts.Repositories;

public class ContractRepository(InvoiceContext invoiceContext) : IContractRepository
{
    private readonly InvoiceContext _invoiceContext = invoiceContext;

    public async Task<IList<Contract>> List()
    {
        var contracts = await _invoiceContext.Contracts.ToListAsync();
        return contracts;
    }
}
