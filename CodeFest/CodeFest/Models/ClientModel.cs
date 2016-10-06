using System.Collections.Generic;
using CodeFest.Models;
using Newtonsoft.Json;

namespace CodeFest.Components
{
    public class ClientModel
    {
        [JsonProperty(PropertyName = "Legal_persona_client")]
        public string LegalPersona;
        [JsonProperty(PropertyName = "Reg_number")]
        public string RegNumber;
        [JsonProperty(PropertyName = "FSP_number")]
        public string FspNumber;
        [JsonProperty(PropertyName = "Risk_profile_client")]
        public string Risk;
        [JsonProperty(PropertyName = "Client")]
        public string ClientName;
        [JsonProperty(PropertyName = "Category")]
        public string ClientCatagory;

        public List<FundModel> Funds { get; set; }


        public ClientModel()
        {
        }
    }
}