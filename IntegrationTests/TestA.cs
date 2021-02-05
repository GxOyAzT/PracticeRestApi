using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using WebAPI;

namespace IntegrationTests
{
    public class TestA
    {
        [Fact]
        public void Test1()
        {
            var x = new WebApplicationFactory<Startup>().CreateClient();

        }
    }
}
