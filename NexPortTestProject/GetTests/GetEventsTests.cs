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
    internal class GetEventsTests
    {
        [Test]
        // A passing test for Get Events API call
        public void GetEventsTestPass()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetEventsRequest testEventInfo = dataHelper.NexportGetEventsInfo();
            //Act
            string authToken = nexportAPIHelper.getAuthToken();
            RestResponse getEventResponse = new NexPortAPIHelper().NexportGetAPI(testEventInfo.GetEventsUrl, authToken, testEventInfo.VersionNumber);
            JArray listResponse = JArray.Parse(getEventResponse.Content);
            JToken eventResponse = listResponse.Where(responseItem => (string)responseItem["id"] == "ivqmld").FirstOrDefault();
            //Assert
            Assert.That(getEventResponse, Is.Not.Null);
            Assert.That((int)getEventResponse.StatusCode, Is.EqualTo(200));
            Assert.That(eventResponse["title"].ToString(), Is.EqualTo("Scrum Training"));
        }
        // A pass test for Get Single Event API call
        [Test]
        public void GetSingleEventTestPass()
        {
            //Arrange
            DataHelpers dataHelper = new DataHelpers();
            NexPortAPIHelper nexportAPIHelper = new NexPortAPIHelper();
            GetRequestList.GetEventsRequest testEventInfo = dataHelper.NexportGetEventsInfo();
            testEventInfo.GetEventsUrl = testEventInfo.GetEventsUrl + "/ivqmld";
            //Act
            string authToken = nexportAPIHelper.getAuthToken();
            RestResponse getEventResponse = new NexPortAPIHelper().NexportGetAPI(testEventInfo.GetEventsUrl, authToken, testEventInfo.VersionNumber);
            JObject getSingleEventResponse = JObject.Parse(getEventResponse.Content);
            JToken attendant = getSingleEventResponse["attendees"].Where(attendeeID => (string)attendeeID["id"] == "lyshnu").FirstOrDefault();
            //Assert
            Assert.That(getEventResponse, Is.Not.Null);
            Assert.That((int)getEventResponse.StatusCode, Is.EqualTo(200));
            Assert.That(attendant["name"].ToString(), Is.EqualTo("Justin Rhea"));
        }
    }
}
