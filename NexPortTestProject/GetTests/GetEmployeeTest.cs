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
    internal class GetEmployeeTests
    {
        [Test]
        // A passing test for Get Client API call
        public void GetEmployeeTestPass()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetEmployeeRequest testEmployeeInfo = dataHelper.NexportGetEmployeeInfo();
            //Act
            string authToken = nexportAPIHelper.getAuthToken();
            RestResponse getEmployeeResponse = new NexPortAPIHelper().NexportGetAPI(testEmployeeInfo.GetEmployeeUrl, authToken, testEmployeeInfo.VersionNumber);
            JArray listResponse = JArray.Parse(getEmployeeResponse.Content);
            JToken testResponse = listResponse.Where(responseItem => (string)responseItem["id"] == "iegmby").FirstOrDefault();
            //Assert
            Assert.That(getEmployeeResponse, Is.Not.Null);
            Assert.That((int)getEmployeeResponse.StatusCode, Is.EqualTo(200));
            Assert.That(testResponse["displayName"].ToString(), Is.EqualTo("Justin Rhea"));
        }
    }
}
