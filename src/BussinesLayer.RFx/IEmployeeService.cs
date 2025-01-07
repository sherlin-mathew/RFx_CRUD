using Models.RFx;

namespace EmployeeBussinesLayer.RFx
{
    public interface IEmployeeService
    { 
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetAllEmployeers();
        //Task<Employee> AddEmployee(Employee employee);
    }
}
