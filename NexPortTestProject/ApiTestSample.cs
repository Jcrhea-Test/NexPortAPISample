using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NexPortApiLearning.NexPort;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RestSharp;
using System;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace NexPortTestProject
{
    public class Tests
    {

        [Test]
        /// This will check if the Authenticate Call responds successfully
        public void PostAuthRequestPass()
        {
            //Arrange
            NexPortAPIHelper helperMethod = new NexPortAPIHelper();
            PostRequestList.AuthPostRequest testUserAuthInfo = helperMethod.UserAuthFromNexportAPISettings();

            //Act
            var testResponse = helperMethod.CreateAuthPostRequest( testUserAuthInfo.AuthUrl, testUserAuthInfo.Username, testUserAuthInfo.Password);
            PostResponseList.NexPortAuthResponse authResponse = JsonConvert.DeserializeObject<PostResponseList.NexPortAuthResponse>(testResponse.Content);

            //Assert
            Assert.That(testResponse, Is.Not.Null);
            Assert.That((int)testResponse.StatusCode, Is.EqualTo(200));

            Assert.That(authResponse, Is.Not.Null);
            Assert.That(authResponse.Username, Is.EqualTo(testUserAuthInfo.Username));

        }
        [Test]
        /// Check to see if the Auth call responds with failure
        public void PostAuthRequestFail()
        {
            //Arrange
            NexPortAPIHelper helperMethod = new NexPortAPIHelper();

            //Act
            var testResponse = helperMethod.CreateAuthPostRequest("http://nxpdev.corp.nexient.com/api/authentication/authenticate", "username", "password");

            //Assert
            Assert.That(testResponse, Is.Not.Null);
            Assert.That((int)testResponse.StatusCode, Is.EqualTo(403));
        }

    }
}