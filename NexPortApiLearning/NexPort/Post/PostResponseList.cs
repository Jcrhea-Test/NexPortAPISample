using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPortApiLearning.NexPort.Post
{
    public class PostResponseList
    {
        public class PostAuthResponse
        {
            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("fullName")]
            public string FullName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("groups")]
            public List<string> Groups { get; set; }
        }
    }
}
