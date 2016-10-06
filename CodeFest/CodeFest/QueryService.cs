using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeFest
{
    class QueryService
    {
        public async Task<string> ping()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://52.164.230.238:3000")
            };
            var response = await client.GetAsync("ping");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<object> query(string text)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://52.164.230.238:3000")
            };
            var response = await client.GetAsync("query/" + text);
            return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
        }
    }
}
