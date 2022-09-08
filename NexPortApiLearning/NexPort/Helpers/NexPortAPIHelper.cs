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
        //Note: Could break this down with params
        //Params: (url, body, version) for Post Request
        public RestResponse NexportPostAPI(string url, JToken jsonBody, string versionNumber)
        {
            string stringJsonBody = jsonBody.ToString();
            RestClient nexportClient = new RestClient(url);
            RestRequest nexportRequest = new RestRequest()
                .AddJsonBody(stringJsonBody)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Version", versionNumber);
            //Using Latest version of RestSharp, IRestResponse is depracted on this verison.
            RestResponse nexportResponse = nexportClient.ExecutePost(nexportRequest);
            return nexportResponse;
        }
        public RestResponse NexportGetAPI(string url, string token, string versionNumber)
        {
            RestClient nexportClient = new RestClient(url);
            RestRequest nexportRequest = new RestRequest()
                .AddHeader("X-Authorization", token)
                .AddHeader("tenantId", "nexient")
                .AddHeader("Version", versionNumber);
            RestResponse nexportResponse = nexportClient.ExecuteGet(nexportRequest);
            return nexportResponse;
        }
        public string getAuthToken()
        {
            DataHelpers dataHelper = new DataHelpers();
            PostRequestList.PostAuthRequest testUserAuthInfo = dataHelper.NexportAuthUserInfo();
            RestResponse authResponse = NexportPostAPI(testUserAuthInfo.AuthUrl, testUserAuthInfo.JsonBody, testUserAuthInfo.VersionNumber);
            string token = authResponse.Headers.Where(x => x.Name == "accessToken").FirstOrDefault().Value.ToString();
            return token;
        }
    }
}
