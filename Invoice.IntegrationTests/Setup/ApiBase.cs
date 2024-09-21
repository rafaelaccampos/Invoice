namespace Invoice.IntegrationTests.Setup;

public class ApiBase : DatabaseBase
{
    protected HttpClient _httpClient;

    [SetUp]
    public new void Setup()
    {
        _httpClient = TestEnvironment.Factory.CreateClient();
    }

    [TearDown]
    public void Teardown()
    {
        _httpClient.Dispose();
    }
}