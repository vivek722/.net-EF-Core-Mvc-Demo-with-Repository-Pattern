using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.Domain.Employee
{
    public class Employee
    {
        public int Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Designation { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public virtual List<Skill>? Skills { get; set; }
    }
   

}
