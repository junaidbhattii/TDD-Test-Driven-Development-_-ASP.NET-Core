using AutoMapper;
using JwtAuthentication_Relations_Authorization.Context;
using JwtAuthentication_Relations_Authorization.Controllers;
using JwtAuthentication_Relations_Authorization.DTO;
using JwtAuthentication_Relations_Authorization.Interfaces;
using JwtAuthentication_Relations_Authorization.Models;
using JwtAuthentication_Relations_Authorization.Services;
using JwtAuthentication_Relations_Authorization.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWholeProject.Test.Controller
{
    public class VenderControllerTest
    {
        [Fact]
        public void VendorRegister_SuccessRegister_ReturnsCorrectResponse()
        {
            // Arrange
            var mockService = new Mock<IVendorService>();
            var expectedRequestResponse = new VendorBodyRequest
            {
                Name = "vendor",
                Email = "vendor@gmail.com",
                Password = "password",
                NoOFDrivers = "23",
                NoOfVehicles = "34",
                VendorAdress = "florida mall",
                ServiceArea = "daytona mall"
            };
            var expecredResponse = new vendorResponse
            {
                NoOfVehicles = "34",
                NoOFDrivers = "23",
                VendorAdress = "florida mall",
                ServiceArea = "daytona mall",
                Latitude = "83.3434",
                Longitude = "22.3232",
                user = new UserResponce
                {
                    Name = "testPerson",
                    Email = "testPerson@gmail.com",
                    Country = "florida",
                    PassCode = "47348",
                    Token = "4u98ru394j9fj49f8j4938fj9384jf934j9fj9",
                    Role = new RoleResponse
                    {
                        Id = 1,
                        Name = "ROLE_ADMIN"
                    }
                }
            };
            mockService.Setup(service => service.VendorRegistration(expectedRequestResponse))
                .ReturnsAsync(expecredResponse);
            var controller = new VendorController(mockService.Object);

            // Act
            var Result = controller.VendorRegister(expectedRequestResponse);

            // Assert
            Assert.NotNull(Result);
            //var ReturnResult = Assert.IsType<vendorResponse>(Result);
            //Assert.Equal(ReturnResult.user.Email , expectedRequestResponse.Email);

        }

    [Fact]
    public void getAllVendor_SuccessRecord_ReturnVendors()
    {
            // Arrange
            var mockService = new Mock<IVendorService>();
            mockService.Setup(service => service.GetAllVendorRecord())
                .Returns(new List<vendorResponse>
                {
                    new vendorResponse
                    {
                         NoOfVehicles = "34",
                        NoOFDrivers = "23",
                        VendorAdress = "florida mall",
                        ServiceArea = "daytona mall",
                        Latitude = "83.3434",
                        Longitude = "22.3232",
                        user = new UserResponce
                        {
                             Name = "testPerson",
                            Email = "testPerson@gmail.com",
                            Country = "florida",
                            PassCode = "47348",
                            Token = "4u98ru394j9fj49f8j4938fj9384jf934j9fj9",
                            Role = new RoleResponse
                            {
                                Id = 1,
                                Name = "ROLE_ADMIN"
                            }
                        }
                    },
                    new vendorResponse
                    {
                         NoOfVehicles = "34",
                        NoOFDrivers = "23",
                        VendorAdress = "florida mall",
                        ServiceArea = "daytona mall",
                        Latitude = "83.3434",
                        Longitude = "22.3232",
                        user = new UserResponce
                        {
                             Name = "testvendot",
                            Email = "testvendor@gmail.com",
                            Country = "florida",
                            PassCode = "47348",
                            Token = "4u98ru394j9fj49f8j4938fj9384jf934j9fj9",
                            Role = new RoleResponse
                            {
                                Id = 1,
                                Name = "ROLE_ADMIN"
                            }
                        }
                    },
                });
            var controller = new VendorController(mockService.Object);
       

        // Act
        var Result = controller.GetAllVendords();
        // Assert
            Assert.NotNull(Result);
            var ReturnResult = Assert.IsType<List<vendorResponse>>(Result);
            Assert.Equal(2, ReturnResult.Count);

        // Add more assertions to validate the returned vendor list as needed
    }
    }


}
