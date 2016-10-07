using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CodeFest.Components;
using CodeFest.Models;
using Newtonsoft.Json.Linq;

namespace CodeFest
{
    public class SpeechService
    {
        public async Task<QueryServiceResponse> RecognizeAsync(string audioBytes)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://52.164.230.238:3000")
            };

            var body = new JObject
            {
                {
                    "audio", new JObject
                    {
                        {"content", audioBytes}
                    }
                },
                {
                    "config", new JObject
                    {
                        {"encoding", "LINEAR16"},
                        {"languageCode", "en-ZA"},
                        {"sampleRate", 16000}
                    }
                }
            };

            var response =
                await client.PostAsync("speech", new StringContent(body.ToString(), Encoding.UTF8, "application/json"));
            var data = JObject.Parse(await response.Content.ReadAsStringAsync());
            var a = data["clients"] as JArray;
            var b = a.First();
            var model = b.ToObject<ClientModel>();
            model.Funds.RemoveAll(f => string.IsNullOrEmpty(f.LegalPersonaFund));

            var intentResp = data["queryResponse"]["intent"] as JObject;
            var intentObj = intentResp.ToObject<QueryResponse>();

            var responseObj = new QueryServiceResponse();
            responseObj.clientModel = model;
            responseObj.queryResponse = intentObj;

            return responseObj;
        }
    }
}