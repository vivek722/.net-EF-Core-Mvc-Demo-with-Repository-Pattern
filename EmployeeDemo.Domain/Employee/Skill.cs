using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.Domain.Employee
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string? skill_name { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
