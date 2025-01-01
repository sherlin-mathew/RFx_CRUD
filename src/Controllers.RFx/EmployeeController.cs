using Microsoft.AspNetCore.Mvc;
using Models.RFx;
using EmployeeBussinesLayer.RFx;
using Microsoft.Extensions.Logging;
namespace EmployeeControllers.RFx
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    { 
        private readonly IEmployeeBussines _employeeService;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(IEmployeeBussines employeeService, ILogger<EmployeesController> logger) 
        { 
            _employeeService = employeeService;
            _logger = logger;
        } 
        [HttpGet] 
        public async Task<ActionResult<Employee>> GetEmployeeById(int id) 
        {
            _logger.LogInformation("Received request to get employee by ID: {Id}", id);
            var employee = await _employeeService.GetEmployeeById(id); 
            if (employee == null) 
            {
                _logger.LogWarning("Employee with ID {Id} not found", id);
                return NotFound(); 
            }
            _logger.LogInformation("Returning employee details for ID: {Id}", id);
            return Ok(employee);
        } 
    }
}
