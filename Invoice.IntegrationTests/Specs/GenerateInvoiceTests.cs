using Invoice.Domain.Contracts.Entities;
using Invoice.Domain.Payments.Entities;
using Invoice.IntegrationTests.Setup;

namespace Invoice.IntegrationTests.Specs
{
    public class GenerateInvoiceTests : DatabaseBase
    {
        [Test]
        public async Task DeveGerarNotaFiscalPorRegimeDeCaixa() 
        {
            //Preciso inserir no banco as duas tabelas Contract e Payment
            //Preciso chamar GenerateInvoice
            //E o assert com a data e o valor do pagamento

            var contract = new Contract("Prestação de Serviços Escolares", 6000, 12);
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            var payment = new Payment(contract, 6000);
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            //var contract = new
            //{
            //    Id = Guid.NewGuid(),
            //    "Prestação de Serviços Escolares",
            //    6000,
            //    12,
            //    DateTime.Now,
            //};
            //var invoiceContext = _context.Contracts.Add()
        }
    }
}
