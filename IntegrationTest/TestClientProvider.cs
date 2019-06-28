using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Project2;
using System;
using System.Net.Http;
using Xunit;

namespace IntegrationTest
{
    [CollectionDefinition("Database collection", DisableParallelization = false)]
    public class DatabaseCollection : ICollectionFixture<TestClientProvider>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class TestClientProvider : IDisposable
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server?.Dispose();
            Client?.Dispose();
        }
    }
}
