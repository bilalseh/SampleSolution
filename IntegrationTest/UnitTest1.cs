using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    [Collection("Database collection")]
    public class UnitTest1
    {
        private HttpClient _client;

        public UnitTest1(TestClientProvider testClientProvider)
        {
            _client = testClientProvider.Client;
        }

        [Fact]
        public async Task Test1()
        {
            var response = await _client.GetAsync("/api/home");
            var content = response.Content.ReadAsStringAsync().Result;
            content.Should().Be("Main Get Api");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test2()
        {
            var response = await _client.GetAsync("/api/home/13");
            var content = response.Content.ReadAsStringAsync().Result;
            content.Should().Be("26");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
