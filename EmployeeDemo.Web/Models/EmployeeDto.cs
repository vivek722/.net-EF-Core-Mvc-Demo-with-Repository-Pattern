using EmployeeDemo.Domain.Employee;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDemo.Web.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string? First_Name { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string? Last_Name { get; set; }
        [DisplayName("Email")]
        [Required]
        public string? Email { get; set; }
        [DisplayName("Gender")]
        [Required]
        public string? Gender { get; set; }
        [DisplayName("DOB")]
        [Required]
        public DateTime? DOB { get; set; }
        [DisplayName("JoiningDate")]
        [Required]
        public DateTime? JoiningDate { get; set; }
        [DisplayName("Designation")]
        [Required]
        public string Designation { get; set; }
        [DisplayName("Image")]
        public string? Image { get; set; }
        [DisplayName("Description")]
        [Required]
        public string? Description { get; set; }
        public string? Skill_Name { get; set; }
        public List<string> skillList { get; set; }

    }
   

    public enum Designation
    {
        ProjectManager,
        Sr_Manager,
        jr_Manager,
        Team_Leader
    }
}
