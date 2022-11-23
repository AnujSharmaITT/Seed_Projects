using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace API_Automation.Common
{
    /// <summary>
    /// Common Bindings For Request.
    /// </summary>
    [Binding]
    public class RequestFeatureSteps
    {
        private RestRequest request;
        private RestResponse response;
        private readonly Utils utils;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        [Given(@"user creates a '(.*)' request for '(.*)'")]
        public void GivenUserCreateTheRestRequest(HttpVerbs method, string endpoint)
        {
            if (method == HttpVerbs.Get)
            {
                this.request = this.utils.CreateRestRequest(Method.Get, endpoint);
            }
            else if (method == HttpVerbs.Post)
            {
                this.request = this.utils.CreateRestRequest(Method.Post, endpoint);
            }
            _scenarioContext[Constants.RestRequest] = this.request;
        }

        [Then(@"user validates the response status code to be '(.*)'")]
        public void ThenUserValidateTheAPIResponseStatusCode(string statusCode)
        {
            this.response = this.GetTheContextResponse();
            if (statusCode != null)
            {
                Assert.AreEqual(statusCode, this.response.StatusCode.ToString());
            }
        }

        [Then(@"user validate the response content is not null")]
        public void ThenUserValidateTheAPIResponseContentIsNotNull()
        {
            this.response = this.GetTheContextResponse();
            Assert.IsNotNull(this.response.Content);
        }

        public RestRequest GetTheContextRequest()
        {
            return (RestRequest)_scenarioContext[Constants.RestRequest];
        }

        public void SetTheContextRequest(RestRequest request)
        {
            _scenarioContext[Constants.RestRequest] = request;
        }

        public RestResponse GetTheContextResponse()
        {
            return (RestResponse)_scenarioContext[Constants.RestResponse];
        }

        public void SetTheContextResponse(RestResponse response)
        {
            _scenarioContext[Constants.RestResponse] = response;
        }

        public void SetTheContextDeserializedResponse(dynamic deserializedResponse)
        {
            _scenarioContext[Constants.DeserializedResponse] = deserializedResponse;
        }

        public dynamic GetTheContextDeserializedResponse()
        {
            return (dynamic)_scenarioContext[Constants.DeserializedResponse];
        }
    }
}
