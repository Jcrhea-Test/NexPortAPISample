using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

namespace NexPortTestProject.PostTests
{
    public class PostTests
    {
        [Test]
        /// This will check if the Authenticate Call responds successfully
        public void PostAuthRequestPass()
        {
            //Arrange
            DataHelpers helperMethod = new DataHelpers();
            PostRequestList.PostAuthRequest testUserAuthInfo = helperMethod.NexportAuthUserInfo();
            //Act
            RestResponse restResponse = new NexPortAPIHelper().NexportPostAPI(testUserAuthInfo.AuthUrl, testUserAuthInfo.JsonBody.ToString(), testUserAuthInfo.VersionNumber);
            PostResponseList.PostAuthResponse authResponse = JsonConvert.DeserializeObject<PostResponseList.PostAuthResponse>(restResponse.Content);
            //Assert
            Assert.That(restResponse, Is.Not.Null);
            Assert.That((int)restResponse.StatusCode, Is.EqualTo(200));
            Assert.That(authResponse, Is.Not.Null);
            Assert.That(authResponse.Username, Is.EqualTo(testUserAuthInfo.JsonBody["username"].ToString()));
        }
        [Test]
        /// Check to see if the Auth call responds with failure
        public void PostAuthRequestFail()
        {
            //Arrange
            DataHelpers helperMethod = new DataHelpers();
            PostRequestList.PostAuthRequest testUserAuthInfo = helperMethod.NexportAuthUserInfo();
            testUserAuthInfo.JsonBody["username"] = "username";
            testUserAuthInfo.JsonBody["password"] = "password";
            //Act
            RestResponse restResponse = new NexPortAPIHelper().NexportPostAPI(testUserAuthInfo.AuthUrl, testUserAuthInfo.JsonBody.ToString(), testUserAuthInfo.VersionNumber);
            //Assert
            Assert.That(restResponse, Is.Not.Null);
            Assert.That((int)restResponse.StatusCode, Is.EqualTo(403));
        }
    }
}