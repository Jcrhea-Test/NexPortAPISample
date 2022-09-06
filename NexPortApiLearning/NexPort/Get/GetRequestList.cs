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
            [JsonProperty("version")]
            public string VersionNumber { get; set; }
        }
        public class GetEmployeeRequest
        {
            [JsonProperty("url")]
            public string GetEmployeeUrl  { get; set; }
            [JsonProperty("version")]
            public string VersionNumber { get; set; }
        }
        public class GetEventsRequest
        {
            [JsonProperty("url")]
            public string GetEventsUrl { get; set; }
            [JsonProperty("version")]
            public string VersionNumber { get; set; }
        }

        public class GetProfilesRequest
        {
            [JsonProperty("url")]
            public string ProfileUrl { get; set; }
            [JsonProperty("version")]
            public string VersionNumber { get; set; }
        }
        public class GetProjectsRequest
        {
            [JsonProperty("url")]
            public string ProjectUrl { get; set; }
            [JsonProperty("version")]
            public string VersionNumber { get; set; }
        }

    }
}
