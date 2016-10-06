using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeFest.Models
{
    class QueryResponse
    {
        [JsonProperty(PropertyName = "intent")]
        public string intentName;
    }

}
