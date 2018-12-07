using System;
using Xunit;

namespace RingCentral.Tests
{
    public class RestClientTest
    {
        [Fact]
        public async void AuthorizeTest()
        {
            var rc = new RestClient("", "", false);
            var result = await rc.Authorize("username", "exension", "password");
            var s = await result.Content.ReadAsStringAsync();
            Console.WriteLine(s);
        }
    }
}
