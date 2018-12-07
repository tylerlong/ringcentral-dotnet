using System;
using Xunit;

namespace RingCentral.Tests
{
    public class RestClientTest
    {
        [Fact]
        public async void GetTest()
        {
            var rc = new RestClient();
            var result = await rc.Get("http://github.com");
            Assert.Contains("GitHub", result);
        }
    }
}
