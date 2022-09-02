using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPortApiLearning.NexPort.Get
{
    public class GetRequestList
    {
        public class GetClientRequest
        {
            [JsonProperty("url")]
            public string GetClientUrl { get; set; }
        }
    }
}
