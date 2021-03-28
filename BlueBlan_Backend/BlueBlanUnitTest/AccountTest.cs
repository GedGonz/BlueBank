using BlueBan.Aplication.Entitydto;
using BlueBlan_Backend;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BlueBlanUnitTest
{
    public class AccountTest : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly HttpClient httpClient;

        public AccountTest(WebApplicationFactory<Startup> factory)
        {
            httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task loginTest()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/login")
            {
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    username = "Admin",
                    password = "Admin123*"
                }), Encoding.UTF8, "application/json")
            };


            // Act
            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task getAccountsUnAuthorized()
        {
            // Arrange
            var response = await httpClient.GetAsync("/api/account");

            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Fact]
        public async Task getAccountsauthorized()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/account")
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            // Act
            var accessToken = FakeJwtManager.GenerateJwtToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task newClientauthorized()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/client")
            {
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    name = "pepito",
                    lastname = "Bonilla"
                }), Encoding.UTF8, "application/json")
            };

            // Act
            var accessToken = FakeJwtManager.GenerateJwtToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task deleteClientauthorized()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/client/f594f67a-7640-4086-0133-08d8f1837527")
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            // Act
            var accessToken = FakeJwtManager.GenerateJwtToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task newClientBadRequestAuthorized()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/client")
            {
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    name = "pepito"
                }), Encoding.UTF8, "application/json")
            };

            // Act
            var accessToken = FakeJwtManager.GenerateJwtToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
