using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace NfcReaderCloud.IntegrationTests
{
    public class UserInfoControllerTests
    {
        public UserInfoControllerTests()
        {

        }

        [Fact]
        public async void AddUser_ShoudReturnOk_SendUser()
        {
            //Arrange
            var user = new User()
            {
                Id = 1,
                UsbDeviceId = "99",
                Name = "Sam"
            };

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var userService = services.SingleOrDefault(d => d.ServiceType == typeof(IUserService));
                    services.Remove(userService);

                    var mockService = new Mock<IUserService>();
                    mockService.Setup(_ => _.CreateUser(user)).Returns(Task.CompletedTask);
                    services.AddTransient(_ => mockService.Object);
                });

            });
            await using var application = new WebApplicationFactory<Program>();
            using var client = webHost.CreateClient();


            //Act

            HttpResponseMessage response = await client.PostAsync("/api/UserInfo/AddUser", data);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}