using EmployeeRepositories;
using Models.RFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{ 
    public class EmployeeRepository : IEmployeeRepository 
    { 
        private readonly List<Employee> _employees; 
        public EmployeeRepository() 
        { 
            _employees = new List<Employee> 
            { 
                new Employee { employerID = 1, employerName = "John Doe", employerTaxReference = "hdksjkd",employerAddress1 = "England",employerPostcode = 14567},
                new Employee { employerID = 2, employerName = "Jane Smith", employerTaxReference = "jhyeg",employerAddress1 = "usa",employerPostcode = 34571}, 
                new Employee { employerID = 3, employerName = "Mike Johnson", employerTaxReference = "yuewh",employerAddress1 = "Dubai",employerPostcode = 73456} 
            }; 
        } 
        public async Task<Employee> GetEmployeeById(int id) 
        {
            return _employees.FirstOrDefault(e => e.employerID == id); 
             
        }
    } 
}
