using EmployeeDemo.Domain.Employee;

namespace EmployeeDemo.Web.Models
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string? skill_name { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto? Employee { get; set; }
    }
}
