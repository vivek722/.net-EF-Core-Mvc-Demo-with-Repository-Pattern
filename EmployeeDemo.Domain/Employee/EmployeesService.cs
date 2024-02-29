using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDemo.Domain.Employee;

namespace EmployeeDemo.Domain.Employee
{
    public class EmployeesService : IEmployeesService
    {
          private readonly IEmployeesRepository _repository;
        public EmployeesService(IEmployeesRepository repository)
        {
            _repository = repository;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            return _repository.AddEmployee(employee);
        }

        public Task<Employee> DeleteEmployee(int id)
        {
           return _repository.DeleteEmployee(id);
        }

        public Task<List<Skill>> DeleteSkill(int? id)
        {
            return _repository.DeleteSkill(id);
        }

        public Task<Employee> GetEmployeeById(int? id)
        {
            return _repository.GetEmployeeById(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _repository.GetEmployees();
        }

        public async Task<List<Skill>> getSkillsById(int? id)
        {
         return await _repository.getSkillsById(id); 
        }

        public Task<List<Employee>> searchData(string empSearch)
        {
            return _repository.searchData(empSearch);
        }

        public async Task<Employee> UpdateEmployee(int? id,Employee employee)
        {
            return await _repository.UpdateEmployee(id,employee);
        }      
    }
}
