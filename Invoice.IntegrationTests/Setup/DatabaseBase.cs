using Microsoft.Extensions.DependencyInjection;

namespace Invoice.IntegrationTests.Setup
{
    public class DatabaseBase
    {
        protected static IServiceScope _scope;
        protected static InvoiceContext _context;
        protected Faker Faker { get; } = new Faker("pt_BR");

        [SetUp]
        public void Setup()
        {

        }

        public static T GetService<T>
    }
}
