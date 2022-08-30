using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPortApiLearning.NexPort
{
    public class PostRequestList
    {
        public class AuthPostRequest
        {
            [JsonProperty("authURL")]
            public string AuthUrl { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }
    }
}
