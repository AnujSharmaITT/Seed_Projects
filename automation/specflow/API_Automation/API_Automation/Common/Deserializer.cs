using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation.Common
{
    /// <summary>
    /// DeSerialize Extension.
    /// </summary>
    public static class Deserializer
    {
        /// <summary>
        /// De Serialize Response extension method.
        /// </summary>
        /// <typeparam name="T">T type of Model.</typeparam>
        /// <param name="restResponse">Rest response.</param>
        /// <returns>T type model.</returns>
        public static T DeSerializeResponse<T>(this RestResponse restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse.Content.ToString());
        }
    }
}
