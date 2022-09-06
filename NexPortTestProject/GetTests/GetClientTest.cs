using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NexPortApiLearning.NexPort.Get;
using NexPortApiLearning.NexPort.Helpers;
using NexPortApiLearning.NexPort.JSONData;
using NexPortApiLearning.NexPort.Post;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RestSharp;
using System;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace NexPortTestProject.GetTests
{
    public class GetClientTests
    {

        [Test]
        // A passing test for Get Client API call
        public void GetClientTestPass()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetClientRequest testUserClientInfo = dataHelper.NexportGetClientInfo();
            //Act
            string authToken = nexportAPIHelper.getAuthToken();
            RestResponse getClientResponse = new NexPortAPIHelper().NexportGetAPI(testUserClientInfo.GetClientUrl, authToken, testUserClientInfo.VersionNumber);
            JArray listResponse = JArray.Parse(getClientResponse.Content);
            JToken testResponse = listResponse.Where(responseItem => (string)responseItem["id"] == "avrbml").FirstOrDefault();
            //Assert
            Assert.That(getClientResponse, Is.Not.Null);
            Assert.That((int)getClientResponse.StatusCode, Is.EqualTo(200));
            Assert.That(testResponse["createdBy"].ToString(), Is.EqualTo("tjakobsze"));
        }
        [Test]
        /// Check for error code 500 if token is missing
        public void GetClientTestsFail()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetClientRequest testUserClientInfo = dataHelper.NexportGetClientInfo();
            //Act
            RestResponse getClientResponse = new NexPortAPIHelper().NexportGetAPI(testUserClientInfo.GetClientUrl, "", testUserClientInfo.VersionNumber);
            //Assert
            Assert.That((int)getClientResponse.StatusCode, Is.EqualTo(500));
        }



    }
}