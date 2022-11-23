using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation.Common
{
    /// <summary>
    /// Constants class.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// RestSharp Request object.
        /// </summary>
        public const string RestRequest = "RestRequest";

        /// <summary>
        /// RestSharp Response object.
        /// </summary>
        public const string RestResponse = "RestResponse";

        /// <summary>
        /// Request Token.
        /// </summary>
        public const string RequestToken = "RequestToken";

        /// <summary>
        /// Deserialized Response object.
        /// </summary>
        public const string DeserializedResponse = "DeserializedResponse";

        /// <summary>
        /// Header key for authorization.
        /// </summary>
        public const string AuthorizationHeaderKey = "authorization";

        /// <summary>
        /// Content Type for header.
        /// </summary>
        public const string ContentTypeKey = "Content-Type";

        /// <summary>
        /// Format type of request.
        /// </summary>
        public const string RequestFormatType = "application/json";
    }
}
