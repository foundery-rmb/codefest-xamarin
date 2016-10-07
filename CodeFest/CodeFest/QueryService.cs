using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CodeFest.Components;
using CodeFest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public async Task<QueryServiceResponse> query(string text)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://52.164.230.238:3000")
            };
            var response = await client.GetAsync("query/" + text);
            var data = JObject.Parse(await response.Content.ReadAsStringAsync());
            var a = data["clients"] as JArray;

            JToken b;
            ClientModel model;
            if (a.HasValues)
            {
                b = a.First;
                model = b.ToObject<ClientModel>();
                model.Funds.RemoveAll(f => string.IsNullOrEmpty(f.LegalPersonaFund));
            }
            else
            {
                model = new ClientModel();
                model.ClientName = "No Data";
            }

            var intentResp = data["queryResponse"]["intent"] as JObject;
            var intentObj = intentResp.ToObject<QueryResponse>();

            var responseObj = new QueryServiceResponse();
            responseObj.clientModel = model;
            responseObj.queryResponse = intentObj;

            return responseObj;
        }
    }
}
