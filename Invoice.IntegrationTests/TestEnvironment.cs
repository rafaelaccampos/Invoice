using Invoice.IntegrationTests.Setup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Invoice.IntegrationTests;

[SetUpFixture]
public class TestEnvironment
{
    public static WebApplicationFactory<Program> Factory;

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        Factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            DatabaseCreator.CreateDatabase(configuration.GetConnectionString("Invoice")!);
            builder.UseConfiguration(configuration);
        });
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
        Factory.Dispose();
    }
}