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
    internal class GetProjectsTest
    {
        [Test]
        public void GetProjectTestPass()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetProjectsRequest testEventInfo = dataHelper.NexportGetProjectsInfo();
            //Act
            string authToken = nexportAPIHelper.getAuthToken();
            RestResponse getProjectResponse = new NexPortAPIHelper().NexportGetAPI(testEventInfo.ProjectUrl, authToken, testEventInfo.VersionNumber);
            JArray listResponse = JArray.Parse(getProjectResponse.Content);
            JToken projectResponse = listResponse.Where(profileItem => (string)profileItem["id"] == "kfaget").FirstOrDefault();
            //Assert
            Assert.That(getProjectResponse, Is.Not.Null);
            Assert.That((int)getProjectResponse.StatusCode, Is.EqualTo(200));
            Assert.That(projectResponse["name"].ToString(), Is.EqualTo("G2 Quality Control Application"));
        }
    }
}
