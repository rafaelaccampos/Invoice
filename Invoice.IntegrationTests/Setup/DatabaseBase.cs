﻿using Bogus;
using Invoice.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;

namespace Invoice.IntegrationTests.Setup;

public class DatabaseBase
{
    protected static IServiceScope _scope;
    protected static InvoiceContext _context;
    protected Faker Faker { get; } = new Faker("pt_BR");

    [SetUp]
    public async Task Setup()
    {
        _scope = TestEnvironment.Factory.Services.CreateScope();
        _context = TestEnvironment.Factory.Services.CreateScope().ServiceProvider.GetService<InvoiceContext>()!;

        var configuration = (IConfigurationRoot)TestEnvironment.Factory.Services.GetService(typeof(IConfiguration))!;
        var connectionString = configuration.GetConnectionString("Invoice");

        var respawner = await Respawner.CreateAsync(connectionString!, new RespawnerOptions
        {
            TablesToIgnore =
            [
                "VersionInfo",
            ]
        });

        await respawner!.ResetAsync(connectionString!);
    }

    public static T GetService<T>()
    {
        return _scope.ServiceProvider.GetService<T>()!;
    }

    [TearDown]
    public void Dispose()
    {
        _scope?.Dispose();
    }
}
