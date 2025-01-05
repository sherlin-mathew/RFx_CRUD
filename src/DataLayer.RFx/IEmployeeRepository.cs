using Models.RFx;
namespace EmployeeRepositories 
{ 
    public interface IEmployeeRepository 
    { 
        Task<Employee> GetEmployeeById(int id); 
        Task<List<Employee>> GetAllEmployeers();
    } 
}
