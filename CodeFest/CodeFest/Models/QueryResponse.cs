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
//        public Intent intent;

        [JsonProperty(PropertyName = "intent")]
        public string intentName;
    }

//    internal class Intent
//    {
//
//        public string intentName;
//    }
}
