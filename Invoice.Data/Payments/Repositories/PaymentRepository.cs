using Invoice.Domain;
using Invoice.Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data.Payments.Repositories;

public class PaymentRepository(InvoiceContext invoiceContext) : IPaymentRepository
{
    private readonly InvoiceContext _invoiceContext = invoiceContext;

    public async Task<IList<Payment>> GetPaymentsByContract(Guid idContract)
    {
        var payments = await _invoiceContext
            .Payments
            .Where(x => x.IdContract == idContract)
            .ToListAsync();

        return payments;
    }
}
