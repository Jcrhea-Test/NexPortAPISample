using Newtonsoft.Json.Linq;
using NexPortApiLearning.NexPort.Get;
using NexPortApiLearning.NexPort.Helpers;
using NexPortApiLearning.NexPort.JSONData;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPortTestProject.GetTests
{
    public class GetProfileTest
    {
        [Test]
        public void GetProfileTestPass()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetProfilesRequest testEventInfo = dataHelper.NexportGetProfilesInfo();
            //Act
            string authToken = nexportAPIHelper.getAuthToken();
            RestResponse getEventResponse = new NexPortAPIHelper().NexportGetAPI(testEventInfo.ProfileUrl, authToken, testEventInfo.VersionNumber);
            JArray listResponse = JArray.Parse(getEventResponse.Content);
            JToken profileResponse = listResponse.Where(profileItem => (string)profileItem["id"] == "xgjvya").FirstOrDefault();
            //Assert
            Assert.That(getEventResponse, Is.Not.Null);
            Assert.That((int)getEventResponse.StatusCode, Is.EqualTo(200));
            Assert.That(profileResponse["firstName"].ToString(), Is.EqualTo("Justin"));
            Assert.That(profileResponse["lastName"].ToString(), Is.EqualTo("Rhea"));
        } 
    }
}
