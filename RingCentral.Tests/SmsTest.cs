using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace RingCentral.Tests
{
    public class SmsTest
    {
        [Fact]
        public async void SendSms()
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
            responseMessage = await rc.Post("/restapi/v1.0/account/~/extension/~/sms");
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            Assert.Contains("SMS", responseString);
            Assert.Contains("Outbound", responseString);
            Assert.Contains("readStatus", responseString);
        }
    }
}
