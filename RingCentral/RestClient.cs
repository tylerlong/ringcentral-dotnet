using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.server, "/restapi/oauth/token"),
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", username },
                    { "extension", extension },
                    { "password", password },
                }),
                Headers = {
                    { HttpRequestHeader.Authorization.ToString(),  this.BasicHeader}
                }
            };
            return await client.SendAsync(requestMessage);
        }

        private string BasicHeader
        {
            get
            {
                var bytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", this.clientId, this.clientSecret));
                return string.Format("Basic {0}", Convert.ToBase64String(bytes));
            }
        }
    }
}
