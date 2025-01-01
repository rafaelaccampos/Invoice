using FluentAssertions;
using FluentAssertions.Execution;
using Invoice.Data.Contracts.Repositories;
using Invoice.Domain;
using Invoice.Domain.Contracts.Entities;
using Invoice.Domain.Payments.Entities;
using Invoice.IntegrationTests.Setup;

namespace Invoice.IntegrationTests.Specs;

public class GenerateInvoiceTests : DatabaseBase
{
    [Test]
    public async Task DeveGerarNotaFiscalPorRegimeDeCaixa() 
    {
        var contract = new Contract("Prestação de Serviços Escolares", 6000, 12, DateTime.Now.Date);
        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();

        var payment = new Payment(contract, 6000, DateTime.Now.Date);
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var contractRepository = new ContractRepository(_context);

        var generateInvoice = new GenerateInvoice(contractRepository);
        var contractInput = new ContractInput
        {
            Month = DateTime.Now.Month, 
            Year = DateTime.Now.Year,
            Type = "cash"
        };
        var invoices = await generateInvoice.Execute(contractInput);

        using (new AssertionScope())
        {
            invoices.First().Date.Should().Be(DateTime.Now.Date);
            invoices.First().Amount.Should().Be(6000);
        }
    }

    [Test]
    public async Task DeveGerarNotaFiscalPorRegimeDeCompetencia()
    {
        var contract = new Contract("Prestação de Serviços Escolares", 6000, 12, new DateTime(2024, 01, 01));
        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();

        var payments = new List<Payment>
        {
            new(contract, 500, new DateTime(2024, 01, 01)),
        };
        _context.Payments.AddRange(payments);
        await _context.SaveChangesAsync();

        var contractRepository = new ContractRepository(_context);

        var generateInvoice = new GenerateInvoice(contractRepository);
        var contractInput = new ContractInput
        {
            Month = 1,
            Year = 2024,
            Type = "accrual"
        };
        var invoices = await generateInvoice.Execute(contractInput);

        using (new AssertionScope())
        {
            invoices.First().Date.Should().Be(new DateTime(2024, 01, 01));
            invoices.First().Amount.Should().Be(500);
        }
    }
}
