using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Automation.Utilities
{
    public class Handler
    {

        public static T GetContent<T>(RestResponse restResponse)
        {
            var content = restResponse.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
