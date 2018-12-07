using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RingCentral
{
    public class RestClient
    {
        public const string SandboxServer = "https://platform.devtest.ringcentral.com";
        public const string ProductionServer = "https://platform.ringcentral.com";

        public string clientId;
        public string clientSecret;
        public Uri server;

        public RestClient(string clientId, string clientSecret, string server)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.server = new Uri(server);
        }
        public RestClient(string clientId, string clientSecret, bool production = false)
            : this(clientId, clientSecret, production ? ProductionServer : SandboxServer)
        {
        }

        public async Task<HttpResponseMessage> Authorize(string username, string extension, string password)
        {
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(this.server, "/restapi/oauth/token")
            };
            return await client.SendAsync(requestMessage);
        }
    }
}
