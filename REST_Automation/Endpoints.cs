using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Automation
{
    public class EndPoints
    {
        public static readonly string CREAT_USER = "/api/users";
        public static readonly string UPDATE_USER = "/api/users/{id}";
        public static readonly string DELETE_USER = "/api/users/{id}";
        public static readonly string GET_SINGLE_USER = "/api/users/{id}";
        public static readonly string GET_LIST_OF_USERS = "/api/users";
    }
}
