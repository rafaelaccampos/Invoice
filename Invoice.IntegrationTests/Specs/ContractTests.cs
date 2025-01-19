using FluentAssertions;
using FluentAssertions.Execution;
using Invoice.Domain.Contracts.Entities;

namespace Invoice.IntegrationTests.Specs;

public class ContractTests
{
    [Test]
    public void DeveGerarFaturasDeUmContrato()
    {
        var contract = new Contract("Mensalidade faculdade", 6000, 12, new DateTime(2024, 01, 10));

        var invoices = contract.GenerateInvoices("accrual", 1, 2024);

        using (new AssertionScope())
        {
            invoices.First().Date.Should().Be(new DateTime(2024, 01, 10));
            invoices.First().Amount.Should().Be(500);
        }
    }
}
