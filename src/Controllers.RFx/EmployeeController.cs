using Microsoft.AspNetCore.Mvc;
using Models.RFx;
using EmployeeBussinesLayer.RFx;
using Microsoft.Extensions.Logging;
namespace EmployeeControllers.RFx
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    { 
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger) 
        { 
            _employeeService = employeeService;
            _logger = logger;
        } 
        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetEmployeeById(int id) 
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
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllEmployeers()
        {
            _logger.LogInformation("Received request to get all employees");
            var employees = await _employeeService.GetAllEmployeers();
            if (employees == null)
            {
                _logger.LogWarning("No employees found");
                return NotFound();
            }
            _logger.LogInformation("Returning all employees");
            return Ok(employees);
        }
        //[HttpPost]
        //[Route("Create")]
        //public async Task<IActionResult> CreateEmployeer(Employee employee)
        //{
        //    _logger.LogInformation("Received request to create employee");
        //    var newEmployee = await _employeeService.CreateEmployeer(employee);
        //    if (newEmployee == null)
        //    {
        //        _logger.LogWarning("Failed to create employee");
        //        return BadRequest();
        //    }
        //    _logger.LogInformation("Employee created successfully");
        //    return Ok(newEmployee);
        //}
    }
}
