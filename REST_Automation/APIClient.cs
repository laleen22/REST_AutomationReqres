using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace REST_Automation
{
    public interface APIClient
    {
        Task<RestResponse> CreateUser<T>(T payload) where T : class;
        Task<RestResponse> UpdateUser<T>(T payload, String id) where T : class;
        Task<RestResponse> DeleteUser(string id);
        Task<RestResponse> GetUser(string id);
        Task<RestResponse> GetListOfUsers(int pageNo);
    }
}