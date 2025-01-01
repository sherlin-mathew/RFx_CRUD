using Models.RFx;

namespace EmployeeBussinesLayer.RFx
{
    public interface IEmployeeBussines
    { 
        Task<Employee> GetEmployeeById(int id);
    }
}
