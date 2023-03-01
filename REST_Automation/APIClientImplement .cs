using REST_Automation.Auth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Automation
{
    public class APIClientImplement : APIClient, IDisposable
    {
        readonly RestClient client;
        string baseUrl  = "https://reqres.in/";
    

        public APIClientImplement()
        {
            var options = new RestClientOptions(baseUrl);
            client = new RestClient(options)
            {
                // Authenticator is commented as the tested API does not nead neither tokens or credentials
               // Authenticator = new APIAuthenticator()
            };
        }

        public async Task<RestResponse> CreateUser<T>(T payload) where T : class
        {
            var request = new RestRequest(EndPoints.CREAT_USER, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> DeleteUser(string id)
        {
            var request = new RestRequest(EndPoints.DELETE_USER, Method.Delete);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> GetListOfUsers(int pageNo)
        {
            var request = new RestRequest(EndPoints.GET_LIST_OF_USERS, Method.Get);
            request.AddQueryParameter("page", pageNo);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUser(string id)
        {
            var request = new RestRequest(EndPoints.GET_SINGLE_USER, Method.Get);
            request.AddUrlSegment("id", id);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateUser<T>(T payload, string id) where T : class
        {
            var request = new RestRequest(EndPoints.UPDATE_USER, Method.Put);
            request.AddUrlSegment(id, id);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

    }
}
