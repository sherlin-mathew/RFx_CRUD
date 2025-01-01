using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EmployeeRepositories;
using BussinesLayer.RFx;
using Models.RFx;
namespace UnitTest.RFx
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<ILogger<EmployeeService>> _mockLogger;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockLogger = new Mock<ILogger<EmployeeService>>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = 1;
            var expectedEmployee = new Employee { employerID = employeeId, employerName = "John Doe" };
            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeById(employeeId)).ReturnsAsync(expectedEmployee);

            // Act
            var result = await _employeeService.GetEmployeeById(employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEmployee.employerID, result.employerID);
            Assert.Equal(expectedEmployee.employerName, result.employerName);
           // _mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>(), employeeId), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeId = 2;
            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeById(employeeId)).ReturnsAsync((Employee)null);

            // Act
            var result = await _employeeService.GetEmployeeById(employeeId);

            // Assert
            Assert.Null(result);
           // _mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>(), employeeId), Times.Once);
        }
    }

}
