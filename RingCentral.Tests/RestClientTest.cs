using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace RingCentral.Tests
{
    public class RestClientTest
    {
        [Fact]
        public async void AuthorizeTest()
        {
            var env = Environment.GetEnvironmentVariables();
            var rc = new RestClient(
                env["RINGCENTRAL_CLIENT_ID"] as string,
                env["RINGCENTRAL_CLIENT_SECRET"] as string,
                env["RINGCENTRAL_SERVER_URL"] as string
            );
            var responseMessage = await rc.Authorize(
                env["RINGCENTRAL_USERNAME"] as string,
                env["RINGCENTRAL_EXTENSION"] as string,
                env["RINGCENTRAL_PASSWORD"] as string
            );
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            Assert.Contains("access_token", responseString);
        }
    }
}
