using REST_Automation.Models.API_Response;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Automation.Auth
{
    public class APIAuthenticator : AuthenticatorBase

    {

        readonly string baseUrl;
        readonly string clientId;
        readonly string clientSecret;

        public APIAuthenticator() : base("")
        {

        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, token);
        }

        private async Task<string> GetToken()
        {
            var option = new RestClientOptions(baseUrl);
            var client = new RestClient(option)
            {
                Authenticator = new HttpBasicAuthenticator(clientId, clientSecret),
            };

            var request = new RestRequest("oauth2/token").
                 AddParameter("grant_type", "client_credentials");
            var response = await client.PostAsync<TokenResponse>(request);

            return $"{response.TokenType},{response.AccessToken}";
        }
    }
}
