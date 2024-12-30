using Invoice.Domain.Contracts.Entities;

namespace Invoice;

public interface IContractRepository
{
    Task<IList<Contract>> List();
}
