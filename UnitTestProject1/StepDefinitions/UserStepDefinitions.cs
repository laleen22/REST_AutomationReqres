using NUnit.Framework;
using REST_Automation;
using REST_Automation.Models.API_Request;
using REST_Automation.Models.API_Response;
using REST_Automation.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnitTestProject1.StepDefinitions
{
    [Binding]
    public class UserStepDefinitions
    {
        private CreateUserRequest createUserRequest;
        private UpdateUserRequest updateUserRequest;
        private RestResponse response;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;
        private string id;
        private string expectedName;


        public UserStepDefinitions(CreateUserRequest createUserRequest, 
            UpdateUserRequest updateUserRequest,
            ScenarioContext scenarioContext)
        {
            this.createUserRequest = createUserRequest;
            this.updateUserRequest = updateUserRequest;
            this.scenarioContext = scenarioContext;
        }

        [Given(@"User with name ""(.*)""")]
        public void GivenUserWithName(string name)
        {
            createUserRequest.name = name;
        }

        [Given(@"user with job ""(.*)""")]
        public void GivenUserWithJob(string job)
        {
            createUserRequest.job = job;
        }

        [Given(@"user with id ""(.*)""")]
        public void GivenUserWithId(string id)
        {
            this.id = id;
        }

        [Given(@"user with name ""(.*)""")]
        public void GivenUserWithName2(string name)
        {
            expectedName = name;
        }

        [Given(@"update job ""(.*)""")]
        public void GivenUpdateJob(string job)
        {
            updateUserRequest.job = job;
        }

        [Given(@"update name ""(.*)""")]
        public void GivenUpdateName(string name)
        {
            updateUserRequest.name = name;
        }

        [When(@"Send request to create user")]
        public async Task WhenSendRequestToCreateUser()
        {
            var api = new APIClientImplement();
            response = await api.CreateUser<CreateUserRequest>(createUserRequest);
            string ab = "jkl";
        }

        [When(@"Send request to get single user")]
        public async Task WhenSendRequestToGetSingleUserAsync()
        {
            var api = new APIClientImplement();
            response = await api.GetUser(id);
        }

        [When(@"Send request to List users")]
        public async Task WhenSendRequestToListUsersAsync()
        {
            var api = new APIClientImplement();
            response = await api.GetListOfUsers(2);
        }

        [When(@"Send request to update user")]
        public async Task WhenSendRequestToUpdateUserAsync()
        {
            var api = new APIClientImplement();
            response = await api.UpdateUser<UpdateUserRequest>(updateUserRequest, id.ToString());
        }

        [Then(@"Validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Console.WriteLine(code);
            var expectedValue = 201;
            Assert.AreEqual(expectedValue, code);



            var content = Handler.GetContent<CreateUserResponse>(response);
            Assert.AreEqual(createUserRequest.name, content.name);
            Assert.AreEqual(createUserRequest.job, content.job);
        }

        [Then(@"Validate single user is received")]
        public void ThenValidateSingleUserIsReceived()
        {
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Console.WriteLine(code);
            var expectedValue = 200;
            Assert.AreEqual(expectedValue, code);

            var content = Handler.GetContent<SingleUserResponse>(response);

        }

        [Then(@"Validate single user is not received")]
        public void ThenValidateSingleUserIsNotReceived()
        {
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Console.WriteLine(code);
            var expectedValue = 404;
            Assert.AreEqual(expectedValue, code);

            var content = Handler.GetContent<SingleUserResponse>(response);

        }

        [Then(@"Validate user exists ""(.*)""")]
        public void ThenValidateUserExists(string name)
        {
            Boolean nameFound = false;
            var content = Handler.GetContent<ListOfUsersResponse>(response);
            for (int i = 0; i < content.per_page; i++)
            {
                if (content.data[i].first_name.ToString().Equals("Lindsay") && content.data[i].last_name.ToString().Equals("Ferguson"))
                {
                    nameFound = true;
                    break;
                }
            }
            Assert.AreEqual(nameFound, true);
        }

        [Then(@"Validate user is updated")]
        public void ThenValidateUserIsUpdated()
        {
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Console.WriteLine(code);
            var expectedValue = 200;
            Assert.AreEqual(expectedValue, code);

            var content = Handler.GetContent<UpdateUserResponse>(response);
            Assert.AreEqual(updateUserRequest.name, content.name);
            Assert.AreEqual(updateUserRequest.job, content.job);
        }
    }
}
