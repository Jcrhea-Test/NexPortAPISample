using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NexPortApiLearning.NexPort.Post;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace NexPortApiLearning.NexPort.Helpers
{
    public class NexPortAPIHelper
    {
        public RestResponse PostAuthResponse(string url, string username, string password)
        {
            PostRequestList.PostAuthRequest userInfo = new PostRequestList.PostAuthRequest
            {
                Username = username,
                Password = password
            };
            string requestBody = JsonConvert.SerializeObject(userInfo);
            RestClient nexportClient = new RestClient(url);
            RestRequest nexportRequest = new RestRequest()
                .AddJsonBody(requestBody)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Version", "2");
            //Using Latest version of RestSharp, IRestResponse is depracted on this verison.
            RestResponse nexportResponse = nexportClient.ExecutePost(nexportRequest);
            return nexportResponse;
        }
        public RestResponse GetClientAPIResopnse(string url, string token)
        {
            RestClient nexportClient = new RestClient(url);
            RestRequest nexportRequest = new RestRequest()
                .AddHeader("X-Authorization", token)
                .AddHeader("tenantId", "nexient")
                .AddHeader("Version", "1");
            RestResponse nexportResponse = nexportClient.ExecuteGet(nexportRequest);
            return nexportResponse;
        }
        //Return an object with values from the json file.
        public PostRequestList.PostAuthRequest NexportAuthUser()
        {
            string projectDirectoryPath = Path.GetFullPath(@"..\..\..\..\");
            string settingsFile = projectDirectoryPath + @"NexPortApiLearning\NexPort\JSONData\NexportAPISettings.json";
            PostRequestList.PostAuthRequest userInfo = new PostRequestList.PostAuthRequest();
            JObject nexportJSONData = JObject.Parse(File.ReadAllText(settingsFile));
            userInfo = JsonConvert.DeserializeObject<PostRequestList.PostAuthRequest>(nexportJSONData["AuthRequest"].ToString());
            return userInfo;
        }

    }
}
