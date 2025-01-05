using EmployeeBussinesLayer.RFx;
using Models.RFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRepositories;
using Microsoft.Extensions.Logging;


namespace BussinesLayer.RFx
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            _logger.LogInformation("Fetching employee with ID: {Id}", id);
            return await _employeeRepository.GetEmployeeById(id);
        }
        public async Task<List<Employee>> GetAllEmployeers()
        {
            _logger.LogInformation("Fetching all employees");
            return await _employeeRepository.GetAllEmployeers();
        }
    }
}