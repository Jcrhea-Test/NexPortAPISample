using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NexPortApiLearning.NexPort.Helpers;
using NexPortApiLearning.NexPort.Post;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RestSharp;
using System;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace NexPortTestProject.PostTests
{
    public class Tests
    {

        [Test]
        /// This will check if the Authenticate Call responds successfully
        public void PostAuthRequestPass()
        {
            //Arrange
            NexPortAPIHelper helperMethod = new NexPortAPIHelper();
            PostRequestList.PostAuthRequest testUserAuthInfo = helperMethod.NexportAuthUser();

            //Act
            var testResponse = helperMethod.PostAuthResponse(testUserAuthInfo.AuthUrl, testUserAuthInfo.Username, testUserAuthInfo.Password);
            PostResponseList.PostAuthResponse authResponse = JsonConvert.DeserializeObject<PostResponseList.PostAuthResponse>(testResponse.Content);

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
            PostRequestList.PostAuthRequest testUserAuthInfo = helperMethod.NexportAuthUser();

            //Act
            var testResponse = helperMethod.PostAuthResponse(testUserAuthInfo.AuthUrl, "username", "password");

            //Assert
            Assert.That(testResponse, Is.Not.Null);
            Assert.That((int)testResponse.StatusCode, Is.EqualTo(403));
        }



    }
}