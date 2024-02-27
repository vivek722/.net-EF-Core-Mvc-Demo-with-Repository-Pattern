using EmployeeDemo.Domain.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.EF.EmployeesConfigrations
{
    public class SkillConfigration : IEntityTypeConfiguration<Skill>
    {
        
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");
            builder.HasKey(x => x.SkillId);
            builder.Property(x => x.skill_name);
            builder.Property(x => x.EmployeeId);
        }
    }
}
