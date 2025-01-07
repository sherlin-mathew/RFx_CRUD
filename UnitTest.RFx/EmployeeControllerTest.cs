using EmployeeBussinesLayer.RFx;
using EmployeeControllers.RFx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.RFx;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.RFx
{
    public class EmployerControllerTests
    {
        private readonly IEmployeeService _mockEmployerService;
        private readonly ILogger<EmployeeController> _mockLogger;
        private readonly EmployeeController _employerController;

        public EmployerControllerTests()
        {
            _mockEmployerService = Substitute.For<IEmployeeService>();
            _mockLogger = Substitute.For<ILogger<EmployeeController>>();
            _employerController = new EmployeeController(_mockEmployerService, _mockLogger);
        }

        [Fact]
        public async Task GetEmployerById_ShouldReturnOkWithEmployer_WhenEmployerExists()
        {
            // Arrange
            var employerId = 1;
            var expectedEmployer = new Employee { employerID = employerId, employerName = "Wipro" };
            _mockEmployerService.GetEmployeeById(employerId).Returns(expectedEmployer);

            // Act
            var result = await _employerController.GetEmployeeById(employerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEmployer = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(expectedEmployer.employerID, returnedEmployer.employerID);
            Assert.Equal(expectedEmployer.employerName, returnedEmployer.employerName);
            //_mockLogger.Received().LogInformation("Received request to get employer by ID: {Id}", employerId);
            //_mockLogger.Received().LogInformation("Returning employer details for ID: {Id}", employerId);
        }

        [Fact]
        public async Task GetEmployerById_ShouldReturnNotFound_WhenEmployerDoesNotExist()
        {
            // Arrange
            var employerId = 2;
            _mockEmployerService.GetEmployeeById(employerId).Returns((Employee)null);

            // Act
            var result = await _employerController.GetEmployeeById(employerId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            //_mockLogger.Received().LogInformation("Received request to get employer by ID: {Id}", employerId);
            //_mockLogger.Received().LogWarning("Employer with ID {Id} not found", employerId);
        }
    }

}
