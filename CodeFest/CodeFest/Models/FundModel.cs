using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeFest.Models
{
    public class FundModel
    {
        [JsonProperty(PropertyName = "Legal_persona_fund")]
        public string LegalPersonaFund { get; set; }
        [JsonProperty(PropertyName = "Fund_name")]
        public string FundName { get; set; }
        [JsonProperty(PropertyName = "Reg_number_fund")]
        public string RegNumberFund { get; set; }
    }
}
