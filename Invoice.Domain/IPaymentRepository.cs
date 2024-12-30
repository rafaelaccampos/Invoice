using Invoice.Domain.Payments.Entities;

namespace Invoice.Domain;

public interface IPaymentRepository
{
    Task<IList<Payment>> GetPaymentsByContract(Guid idContract);
}