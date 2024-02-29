using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeDemo.Domain.Employee
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int? id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
        Task<Employee> UpdateEmployee(int? id, Employee employee);
        Task<List<Employee>> searchData(string empSearch);
        Task<List<Skill>> DeleteSkill(int? id);
        Task<List<Skill>> getSkillsById(int? id);

    }
}
