using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NexPortApiLearning.NexPort.Get;
using NexPortApiLearning.NexPort.Helpers;
using NexPortApiLearning.NexPort.Post;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPortApiLearning.NexPort.JSONData
{
    public class DataHelpers
    {
        private static readonly string jsonDataPath = Path.GetFullPath(@"..\..\..\..\") + @"NexPortApiLearning\NexPort\JSONData\NexportAPISettings.json";
        private JObject jsonData = JObject.Parse(File.ReadAllText(jsonDataPath));

        //Return an object with values from the json file.
        public PostRequestList.PostAuthRequest NexportAuthUser()
        {
            PostRequestList.PostAuthRequest userInfo = JsonConvert.DeserializeObject<PostRequestList.PostAuthRequest>(jsonData["AuthRequest"].ToString());
            return userInfo;
        }
        public GetRequestList.GetClientRequest NexportGetClientData()
        {
            GetRequestList.GetClientRequest _getClientRequest = JsonConvert.DeserializeObject<GetRequestList.GetClientRequest>(jsonData["GetClientRequest"].ToString());
            return _getClientRequest;
        }
    }
}
