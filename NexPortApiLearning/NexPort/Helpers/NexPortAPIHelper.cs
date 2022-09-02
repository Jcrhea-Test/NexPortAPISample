using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NexPortApiLearning.NexPort.Get;
using NexPortApiLearning.NexPort.JSONData;
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
        public string getAuthToken()
        {
            DataHelpers dataHelper = new DataHelpers();
            PostRequestList.PostAuthRequest testUserAuthInfo = dataHelper.NexportAuthUser();
            RestResponse authResponse = new NexPortAPIHelper().PostAuthResponse(testUserAuthInfo.AuthUrl, testUserAuthInfo.Username, testUserAuthInfo.Password);
            string token = authResponse.Headers.Where(x => x.Name == "accessToken").FirstOrDefault().Value.ToString();
            return token;
        }
    }
}
