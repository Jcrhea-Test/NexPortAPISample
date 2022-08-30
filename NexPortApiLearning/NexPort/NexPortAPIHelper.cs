using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace NexPortApiLearning.NexPort
{
    public class NexPortAPIHelper
    {
        /// <summary>
        /// Calling the Post Request to Authenticate user.
        /// </summary>
        /// <returns>RestResponse object</returns>
        public RestResponse CreateAuthPostRequest(string url, string username, string password)
        {
            PostRequestList.AuthPostRequest userInfo = new PostRequestList.AuthPostRequest
            {
                Username = username,
                Password = password
            };
            string requestBody = JsonConvert.SerializeObject(userInfo);
            

            RestClient nexPortClient = new RestClient(url);
            RestRequest nexportRequest = new RestRequest()
                .AddJsonBody(requestBody)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Version", "2");
            //Using Latest version of RestSharp, IRestResponse is depracted on this verison.
            RestResponse checkTest = nexPortClient.ExecutePost(nexportRequest);
            

            return checkTest;
        }

        public PostRequestList.AuthPostRequest UserAuthFromNexportAPISettings()
        {
            string projectDirectoryPath = System.IO.Path.GetFullPath(@"..\..\..\..\");
            string settingsFile = projectDirectoryPath + @"NexPortApiLearning\NexPort\NexportAPISettings.json";
            PostRequestList.AuthPostRequest userInfo = new PostRequestList.AuthPostRequest();
            using (StreamReader r = new StreamReader(settingsFile))
            {
                string json = r.ReadToEnd();
                userInfo = JsonConvert.DeserializeObject<PostRequestList.AuthPostRequest>(json);
            }
            
            return userInfo;
        }
    }
}
