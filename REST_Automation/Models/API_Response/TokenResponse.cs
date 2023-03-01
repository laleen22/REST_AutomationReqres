using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Automation.Models.API_Response
{
    public class TokenResponse
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
    }
}
