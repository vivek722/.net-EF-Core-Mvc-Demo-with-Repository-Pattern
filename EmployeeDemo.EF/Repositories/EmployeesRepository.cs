using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDemo.Domain.Employee;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemo.EF.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeesRepository(EmployeeDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        //Predicate<string> predicateData =  new Predicate<string>(searchData);

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employeeData = await GetEmployeeById(id);
            dbContext.Employees.Remove(employeeData);  
            await dbContext.SaveChangesAsync();
            return employeeData;

        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await dbContext.Employees.AsNoTracking().Include(x => x.Skills).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await dbContext.Employees.AsNoTracking().Include(x => x.Skills).ToListAsync();
        }

        public async Task<List<Employee>> searchData(string empSearch)
        {
           
            return await dbContext.Employees.Where(x => x.First_Name.Contains(empSearch) || x.Last_Name.Contains(empSearch) || x.Email.Contains(empSearch)).Include(x => x.Skills).ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var EmployeesData = await GetEmployeeById(id);        
            employee.Id = EmployeesData.Id;
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }
        public async Task<List<Skill>> getSkillsById(int id)
        {
            return await dbContext.Skills.AsNoTracking().Where(x => x.EmployeeId == id).ToListAsync();            
        }
        public async Task<List<Skill>> DeleteSkill(int id)
        {
            List<Skill> skillData = await getSkillsById(id);
            foreach (var skill in skillData)
            {
                dbContext.Skills.Remove(skill);
            }
            await dbContext.SaveChangesAsync();
            return skillData;
        }     
    }
}
