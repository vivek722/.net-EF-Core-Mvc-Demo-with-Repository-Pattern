using System;
using EmployeeDemo.Domain.Employee;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeDemo.EF.EmployeesConfigrations
{
    public class EmployeesConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.First_Name);
            builder.Property(x=>x.Last_Name);
            builder.Property(x=>x.Email);
            builder.Property(x=>x.Gender);
            builder.Property(x => x.DOB);
            builder.Property(x => x.JoiningDate);
            builder.Property(x => x.Designation);
            builder.Property(x => x.Image);
            builder.Property(x => x.Designation);

            builder.
                HasMany(e => e.Skills).
                WithOne(e => e.Employee).
                HasForeignKey(e => e.EmployeeId).
                OnDelete(DeleteBehavior.Restrict);
        }



    }
}
