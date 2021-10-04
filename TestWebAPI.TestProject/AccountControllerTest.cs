
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestWebAPI.Controllers;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;
using TestWebAPI.Domain.SPModels;
using TestWebAPI.Service.Interfaces;
using TestWebAPI.Service.Service;
using Xunit;

namespace TestWebAPI.TestProject
{
    public class AccountControllerTest
    {
        private readonly TestServer testServer;
        private readonly HttpClient httpClient;
        public AccountControllerTest()
        {
            testServer = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            httpClient = testServer.CreateClient();
        }

        //[Fact]
        //public async Task GetCategories_Returns_Ok()
        //{
        //    var response = await httpClient.GetAsync($"/api/user-management/users");

        //    response.EnsureSuccessStatusCode();

        //    // Deserialize and examine results.
        //    var result = await response.Content.ReadAsStringAsync();
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public void CreateUserTest()
        //{
        //    // Arrange
        //    Mock<IUserService> postRepositoryMock = new Mock<IUserService>();
        //    UserModel testItem = new UserModel()
        //    {
        //        UserId = 0,
        //        Name = "Test",
        //        Email = "test@test.com",
        //        City = "testCity",
        //        Mobile = "9878766565",
        //        IsUpdate = false
        //    };
        //    ResponseModel response = new ResponseModel()
        //    {
        //        StatusCode = 200,
        //        Message = "Success",
        //        Response = null
        //    };
        //    postRepositoryMock.Setup(
        //        it =>
        //    it.CreateUpdateUser(testItem)).ReturnsAsync(response);
        //    AccountController _controller = new AccountController(postRepositoryMock.Object);


        //    // Act
        //    var createdResponse = _controller.CreateUpdateUser(testItem).Result as OkObjectResult;
        //    // Assert

        //    Assert.IsType<ResponseModel>(createdResponse.Value);
        //    Assert.Equal(response, createdResponse.Value);
        //}
        //[Fact]
        //public void UpdateUserTest()
        //{
        //    // Arrange
        //    Mock<IUserService> postRepositoryMock = new Mock<IUserService>();
        //    UserModel testItem = new UserModel()
        //    {
        //        UserId = 1,
        //        Name = "Test",
        //        Email = "test@test.com",
        //        City = "testCity",
        //        Mobile = "9878766565",
        //        IsUpdate = true
        //    };
        //    ResponseModel response = new ResponseModel()
        //    {
        //        StatusCode = 200,
        //        Message = "Success",
        //        Response = null
        //    };
        //    postRepositoryMock.Setup(
        //        it =>
        //    it.CreateUpdateUser(testItem)).ReturnsAsync(response);
        //    AccountController _controller = new AccountController(postRepositoryMock.Object);


        //    // Act
        //    var createdResponse = _controller.CreateUpdateUser(testItem).Result as OkObjectResult;
        //    // Assert
        //    Assert.IsType<ResponseModel>(createdResponse.Value);
        //    Assert.Equal(response, createdResponse.Value);
        //}


        //[Fact]
        //public void GetUsersTest()
        //{
        //    // Arrange
        //    Mock<IUserService> postRepositoryMock = new Mock<IUserService>();

        //    ResponseModel response = new ResponseModel()
        //    {
        //        StatusCode = 200,
        //        Message = "Success",
        //        Response = GetDummyUsers()

        //    };
        //    postRepositoryMock.Setup(
        //        it =>
        //    it.GetUsers()).ReturnsAsync(response);
        //    AccountController _controller = new AccountController(postRepositoryMock.Object);


        //    // Act
        //    var createdResponse = _controller.Get().Result as OkObjectResult;
        //    // Assert
        //    Assert.IsType<ResponseModel>(createdResponse.Value);
        //    Assert.Equal(response, createdResponse.Value);
        //}

        //[Fact]
        //public void GetUserByIdTest()
        //{
        //    // Arrange
        //    Mock<IUserService> postRepositoryMock = new Mock<IUserService>();

        //    ResponseModel response = new ResponseModel()
        //    {
        //        StatusCode = 200,
        //        Message = "Success",
        //        Response = GetSingleUser()

        //    };
        //    postRepositoryMock.Setup(
        //        it =>
        //    it.GetUserById(1)).ReturnsAsync(response);
        //    AccountController _controller = new AccountController(postRepositoryMock.Object);


        //    // Act
        //    var createdResponse = _controller.GetUserbyId(1).Result as OkObjectResult;
        //    // Assert
        //    Assert.IsType<ResponseModel>(createdResponse.Value);
        //    Assert.Equal(response, createdResponse.Value);
        //}
        //[Fact]
        //public void DeleteUserByIdTest()
        //{
        //    // Arrange
        //    Mock<IUserService> postRepositoryMock = new Mock<IUserService>();

        //    ResponseModel response = new ResponseModel()
        //    {
        //        StatusCode = 200,
        //        Message = "Success",
        //        Response = null

        //    };
        //    postRepositoryMock.Setup(
        //        it =>
        //    it.DeleteUserById(1)).ReturnsAsync(response);
        //    AccountController _controller = new AccountController(postRepositoryMock.Object);


        //    // Act
        //    var createdResponse = _controller.Delete(1).Result as OkObjectResult;
        //    // Assert
        //    Assert.IsType<ResponseModel>(createdResponse.Value);
        //    Assert.Equal(response, createdResponse.Value);
        //}

        //#region HelperMethods
        //public List<SPGetUserModel> GetDummyUsers()
        //{
        //    List<SPGetUserModel> users = new List<SPGetUserModel>();
        //    users.Add(new SPGetUserModel
        //    {
        //        UserId = 1,
        //        Name = "Test User 1",
        //        Email = "testemail1@email.com",
        //        City = "City 1",
        //        Mobile = "9876543210"
        //    });

        //    users.Add(new SPGetUserModel
        //    {
        //        UserId = 2,
        //        Name = "Test User 2",
        //        Email = "testemail2@email.com",
        //        City = "City 2",
        //        Mobile = "9876543210"
        //    });
        //    users.Add(new SPGetUserModel
        //    {
        //        UserId = 3,
        //        Name = "Test User 3",
        //        Email = "testemail3@email.com",
        //        City = "City 3",
        //        Mobile = "9876543210"
        //    });
        //    return users;

        //}
        //public SPGetUserModel GetSingleUser()
        //{
            
        //   return (new SPGetUserModel
        //    {
        //        UserId = 1,
        //        Name = "Test User 1",
        //        Email = "testemail1@email.com",
        //        City = "City 1",
        //        Mobile = "9876543210"
        //    });

        //}
        //#endregion
    }
}
