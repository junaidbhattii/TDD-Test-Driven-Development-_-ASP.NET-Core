using JwtAuthentication_Relations_Authorization.Context;
using JwtAuthentication_Relations_Authorization.Controllers;
using JwtAuthentication_Relations_Authorization.DTO;
using JwtAuthentication_Relations_Authorization.Interfaces;
using JwtAuthentication_Relations_Authorization.Models;
using JwtAuthentication_Relations_Authorization.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication_Relations_Authorization.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void GetAllEmployee_ReturnsListOfEmployeeResponses()
        {
            // Arrange
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(service => service.GetAllEmployeeRecord())
                       .Returns(new List<EmployeeResponse>
                       {
                           new EmployeeResponse { Name = "Employee 1", Department = "Dept 1" },
                           new EmployeeResponse { Name = "Employee 2", Department = "Dept 2" }
                       });
            var controller = new EmployeeController(mockService.Object);

            // Act
            var result = controller.GetAllEmployee();
            //var resultt = controller.GetAllEmployee() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<List<EmployeeResponse>>(result);
            Assert.Equal(2, objectResult.Count);
            // Add more assertions as needed
        }

        [Fact]
        public void GetEmployeeById_ExistingId_ReturnsEmployeeResponse()
        {
            // Arrange
            var mockService = new Mock<IEmployeeService>();
            var expectedEmployee = new EmployeeResponse { Name = "Test Employee", Department = "Test Department" };
            mockService.Setup(service => service.GetEmployeeRecordsById(It.IsAny<int>()))
                       .Returns(expectedEmployee);
            var controller = new EmployeeController(mockService.Object);

            // Act
            var result = controller.GetEmployeeById(1);

            // Assert
            Assert.NotNull(result);
            var employeeResult = Assert.IsType<EmployeeResponse>(result);
            Assert.Equal(expectedEmployee.Name, employeeResult.Name);
            // Add more assertions as needed
        }

        // Similarly, write tests for other actions: CreateEmpRecord, UpdateEmpRecord, and DeleteEmpRecord

        [Fact]

        public void CreateEmpRecord_SuccessEmpRecord_ReturnResponse()
        {
            //Arrage
            var mockService = new Mock<IEmployeeService>();
            var ExpectedEmployee = new EmployeeResponse
            {
                Name = "junaid",
                Email = "junaid@gmail.com",
                Department = "SoftwareEngineer",
                Address = "Lahore",
                StateCode = "934893"
            };
            mockService.Setup(service => service.CreateEmployeeRecord(ExpectedEmployee))
                .Returns(ExpectedEmployee);
            var controller = new EmployeeController (mockService.Object);
            //Act
            var result = controller.CreateEmpRecord(ExpectedEmployee);

            //Assert

            Assert.NotNull(result);
            var employeeResult = Assert.IsType<EmployeeResponse>(result);
            Assert.Equal(ExpectedEmployee.Email, employeeResult.Email);
        }
        [Fact]
        public void UpdateEmployeeRecord_SuccessUpdate_ReturnResponse()
        {
            // Arrange
            var mockService = new Mock<IEmployeeService>();
            var ExpectedResponse = new EmployeeResponse
            {
                Name = "junaid",
                Email = "junaid@gmail.com",
                Department = "SoftwareEngineer",
                Address = "Lahore",
                StateCode = "934893"
            };
            mockService.Setup(service => service.UpdateEmployeeRecord(ExpectedResponse , It.IsAny<int>() ))
                .Returns(ExpectedResponse);
            var controller = new EmployeeController(mockService.Object);
            //Act
            var Result = controller.UpdateEmpRecord(1 ,ExpectedResponse);

            //Assert

            Assert.NotNull(Result);
            var employeeResult = Assert.IsType<EmployeeResponse>(Result);
            Assert.Equal(ExpectedResponse.Email , employeeResult.Email);

        }

        [Fact]

        public void DeleteEmployeeRecord_SuccessDelete_ReturnTrue()
        {
            var mockService = new Mock<IEmployeeService>();
            var ExpectedResult = true;
            mockService.Setup(service => service.DeleteEmployeeRecord(It.IsAny<int>()))
                .Returns(ExpectedResult);
            var controller = new EmployeeController (mockService.Object);
            //Act

            var Result = controller.DeleteEmpRecord(1);

            //Assert 
            Assert.True(Result);
        }
    }
}