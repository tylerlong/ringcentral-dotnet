using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RingCentral
{
    public class RestClient
    {
        public async Task<string> Get(string uri)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
