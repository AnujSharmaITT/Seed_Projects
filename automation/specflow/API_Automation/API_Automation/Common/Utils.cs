using NLog;
using RestSharp;
using NJsonSchema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace API_Automation.Common
{
    /// <summary>
    /// Common Utility class.
    /// </summary>
    public class Utils
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public Utils(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Create Rest Request.
        /// </summary>
        /// <param name="methodType">Type of request.</param>
        /// <returns>Rest Request.</returns>
        public RestRequest CreateRestRequest(Method methodType, string endpoint)
        {
            return new RestRequest(endpoint, methodType);
        }

        /// <summary>
        /// Add valid token in request.
        /// </summary>
        /// <param name="request">Rest request.</param>
        /// <returns>Rest Request.</returns>
        public RestRequest AddTheValidTokenInRestRequest(RestRequest request)
        {
            // Get the token from scenario context 
            var token = (Token)_featureContext[Constants.RequestToken];
            this.logger.Debug("Add the valid token in the quote rest request");

            // Add token in header
            request.AddHeader(Constants.AuthorizationHeaderKey, token.TokenType + " " + token.AccessToken);
            return request;
        }

        /// <summary>
        /// Read file content.
        /// </summary>
        /// <param name="filePath">path of the file</param>
        /// <returns>file content as string.</returns>
        public string ReadFileContent(string filePath)
        {
            return File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath));
        }

        /// <summary>
        /// Build endpoint with one generic query parameter.
        /// </summary>
        /// <param name="endpoint">Endpoint in where query parameter should be added</param>
        /// <param name="map">Map of query parameters.</param>
        /// <returns>Endpoint with query parameter added.</returns>
        public string BuildEndpointWithQueryParameters(string endpoint, Dictionary<string, string> map)
        {
            Uri url = new Uri(endpoint);
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var pair in map)
            {
                query[pair.Key] = pair.Value;
            }
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri.ToString();
        }

        /// <summary>
        /// Add content type to Header.
        /// </summary>
        /// <param name="request">Rest Request</param>
        /// <returns>request</returns>
        public RestRequest AddContentTypeInRequestHeader(RestRequest request)
        {
            request.AddHeader(Constants.ContentTypeKey, Constants.RequestFormatType);
            return request;
        }

        /// <summary>
        /// Validate Schema File.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="response">Response.</param>
        /// <returns>bool</returns>
        public bool ValidateSchemaFile(string path, RestResponse response)
        {
            // read file into a string and parse JsonSchema from the string
            string schemaFile = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path));
            JsonSchema jsonSchema = JsonSchema.FromSampleJson(schemaFile);

            var errors = jsonSchema.Validate(response.Content);
            return errors.Count == 0;
        }
    }
}
