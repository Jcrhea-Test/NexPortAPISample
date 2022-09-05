using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPortApiLearning.NexPort.Post
{
    public sealed class PostRequestList
    {
        public class PostAuthRequest
        {
            [JsonProperty("url")]
            public string AuthUrl { get; set; }

            [JsonProperty("body")]
            public JObject JsonBody { get; set; }

            [JsonProperty("version")]
            public string VersionNumber { get; set; }
        }
    }
}