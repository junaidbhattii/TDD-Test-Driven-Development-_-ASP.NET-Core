using JwtAuthentication_Relations_Authorization.Controllers;
using JwtAuthentication_Relations_Authorization.DTO;
using JwtAuthentication_Relations_Authorization.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication_Relations_Authorization.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void RegistrationUser_SuccessRegister_ReturnResponse()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var expectedRequest = new UserRequestResponse
            {
                Name = "Test",
                Password = "password",
                Email = "Test@gmail.com",
                Country = "Pakistan",
                PassCode = "Testpasscode",
            };
            var ExpectedResponse = new UserResponce
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Country = "Pakistan",
                PassCode = "Testpasscode",
                Token = "jflsdifji3u4ujojfndfjoitj94tjef",
                Role = new RoleResponse
                {   
                    Id = 1,
                    Name = "TestRole",
                }
            };
            mockService.Setup(service => service.RegisterUser(expectedRequest))
                .Returns(ExpectedResponse);
            var controller = new UserController(mockService.Object);

            //Act

            var Result = controller.Registration(expectedRequest);

            //Assert
            Assert.NotNull(Result); 
            var UserResult = Assert.IsType<UserResponce>(Result);   
            Assert.Equal(ExpectedResponse.Email , UserResult.Email);
        }

        [Fact]
        public void LoginUser_SuccessLogin_ReturnResponse()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var expectedRequest = new LoginRequest
            {
                Email = "Test@gmail.com",
                Password = "password",
            };
            var ExpectedResponse = new UserResponce
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Country = "Pakistan",
                PassCode = "Testpasscode",
                Token = "jflsdifji3u4ujojfndfjoitj94tjef",
                Role = new RoleResponse
                {
                    Id = 1,
                    Name = "TestRole",
                }
            };
            mockService.Setup(service => service.LoginUser(expectedRequest))
                .Returns(ExpectedResponse);
            var controller = new UserController(mockService.Object);
            //Act

            var Result = controller.Login(expectedRequest);
            //Assert

            Assert.NotNull(Result);
            //Assert.NotEmpty(Result);
            var LoginResult = Assert.IsType<UserResponce> (Result);
            Assert.Equal(expectedRequest.Email, LoginResult.Email);
            
        }
    }
}
