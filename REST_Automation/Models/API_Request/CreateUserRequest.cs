using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Automation.Models.API_Request
{
    public class CreateUserRequest
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}
