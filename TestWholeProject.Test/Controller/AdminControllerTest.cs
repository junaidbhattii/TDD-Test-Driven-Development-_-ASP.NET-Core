using JwtAuthentication_Relations_Authorization.Controllers;
using JwtAuthentication_Relations_Authorization.DTO;
using JwtAuthentication_Relations_Authorization.Interfaces;
using JwtAuthentication_Relations_Authorization.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication_Relations_Authorization.Tests.Controllers
{
    public class AdminControllerTest
    {
        [Fact]
        public void AddAdmin_SuccessAddition_ReturnResponse()
        {
            //Arrange
            var mockService = new Mock<IAdminService>();
            var expectedRequest = new AdminRequestBody
            {
                Email = "testAdmin@gmail.com",
                Password = "password",
                Name = "name",
                AdminAdress = "lahore pakistan"
            };
            var expectedResponse = new AdminResponse
            {
                AdminAdress = "pakistan",
                AdminEmail = "admin@gmail.com",
                AdminName = "name",
                userResponce = new UserResponce
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
                }
            };
            mockService.Setup(service => service.AddAdminRecord(expectedRequest))
                .Returns(expectedResponse);
            var controller = new AdminController(mockService.Object);
            //Act
            var Result = controller.AddAdmin(expectedRequest);
            //Assert

            Assert.NotNull(Result);
            var AdminResult = Assert.IsType<AdminResponse>(Result);
            Assert.Equal(expectedResponse.AdminEmail , AdminResult.AdminEmail);
        }

        [Fact]

        public void GetAllAdmins_SucccessGetAdmins_ReturnAdmins()
        {
            //Arrange
            var mockService = new Mock<IAdminService>();
            mockService.Setup(service => service.GetAllAdmins())
                .Returns(new List<AdminResponse>()
                {
                    new AdminResponse
                    {
                        AdminAdress = "pakistan",
                        AdminEmail = "admin@gmail.com",
                        AdminName = "name",
                        userResponce = new UserResponce
                        {
                            Name = "Test",
                            Email = "Test@gmail.com",
                            Country = "Pakistan",
                            PassCode = "Testpasscode",
                            Token = "jflsdifji3u4ujojfndfjoitj94tjef",
                            Role = new RoleResponse
                            {
                                Id = 1,
                                Name = "ROLE_ADMIN",
                            }
                        }
                    },
                    new AdminResponse
                    {
                        AdminAdress = "pakistan",
                        AdminEmail = "adminperson@gmail.com",
                        AdminName = "name",
                        userResponce = new UserResponce
                        {
                            Name = "Test",
                            Email = "Testperson@gmail.com",
                            Country = "Pakistan",
                            PassCode = "Testpasscode",
                            Token = "jflsdifji3u4ujojfndfjoitj94tjef",
                            Role = new RoleResponse
                            {
                                Id = 1,
                                Name = "ROLE_ADMIN",
                            }
                        }
                    },
                });
            var controller = new AdminController(mockService.Object);
            //Act
            var Result = controller.GetAdmins();
            //Assert

            Assert.NotNull(Result);
            var AdminResult = Assert.IsType<List<AdminResponse>>(Result);
            Assert.Equal(2 , AdminResult.Count);
        }

        [Fact]

        public void GetAllUserByAdmin_SuccessGetAdmins_ReturnResponse()
        {
            //Arrange
            var mockService = new Mock<IAdminService>();
            mockService.Setup(service => service.GetAllUsers())
                .Returns(new List<AdminUserResponsecs>
                {
                    new AdminUserResponsecs
                    {
                        Id = 1,
                        Name = "users",
                        Email = "user@gmail.com",
                        Country = "pakistan",
                        PassCode = "8948",
                        Role = new RoleResponse
                        {
                            Id = 1,
                            Name = "ROLE_USER"
                        }
                    },
                    new AdminUserResponsecs
                    {
                        Id = 1,
                        Name = "usersPerson",
                        Email = "userPerson@gmail.com",
                        Country = "pakistan",
                        PassCode = "8948",
                        Role = new RoleResponse
                        {
                            Id = 2,
                            Name = "ROLE_USER"
                        }
                    },

                });
            var controller = new AdminController(mockService.Object);

            // Act

            var Result = controller.GetAllUsersRecords();

            //Assert

            Assert.NotNull(Result);
            var ResultResponse = Assert.IsType<List<AdminUserResponsecs>>(Result);    
            Assert.Equal(2 , ResultResponse.Count);
        }

        [Fact]

        public void GetAllVendor_SuccessGetVendor_ReturnResponse()
        {
            //Arrange
            var mockService = new Mock<IAdminService>();
            mockService.Setup(service => service.GetAllVendorsByAdmin())
                .Returns(new List<AdminVendorResponse>
                {
                    new AdminVendorResponse
                    {
                        Id = 1,
                        NoOfVehicles = "12",
                        VendorAdress = "florida",
                        ServiceArea = "pakistan",
                        Latitude = "23.8948",
                        Longitude = "87.3434",
                        adminUserResponsecs = new AdminUserResponsecs
                        {
                                Id = 1,
                            Name = "usersPerson",
                            Email = "userPerson@gmail.com",
                            Country = "pakistan",
                            PassCode = "8948",
                            Role = new RoleResponse
                            {
                                Id = 2,
                                Name = "ROLE_USER"
                            }
                        }
                    },
                    new AdminVendorResponse
                    {
                         Id = 1,
                        NoOfVehicles = "12",
                        VendorAdress = "florida",
                        ServiceArea = "pakistan",
                        Latitude = "23.8948",
                        Longitude = "87.3434",
                        adminUserResponsecs = new AdminUserResponsecs
                        {
                                Id = 1,
                            Name = "usersPerson",
                            Email = "userPerson@gmail.com",
                            Country = "pakistan",
                            PassCode = "8948",
                            Role = new RoleResponse
                            {
                                Id = 2,
                                Name = "ROLE_USER"
                            }
                        }
                    }
                });
            var controller = new AdminController(mockService.Object);

            // Act

            var Result = controller.GetAllVendorRecords();

            //Assert

            Assert.NotNull(Result);
            var ResultResponse = Assert.IsType<List<AdminVendorResponse>>(Result);
            Assert.Equal(2, ResultResponse.Count);
        }
    }
}
