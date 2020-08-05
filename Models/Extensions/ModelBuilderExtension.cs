using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Extensions
{
    public static class ModelBuilderExtension
    {
       public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    Id = 1,
                    Name = "Jeff",
                    Email = "nyake@yahoo.com",
                    Department = Enums.Dept.IT
                },

                new Employee
                {
                    Id = 2,
                    Name = "Nyake",
                    Email = "nyake@yahoo.com",
                    Department = Enums.Dept.IT
                },

                new Employee
                {
                    Id = 3,
                    Name = "Bruce",
                    Email = "bruce@hotmail.com",
                    Department = Enums.Dept.HR
                },

                new Employee
                {
                    Id = 4,
                    Name = "Oloo",
                    Email = "oloo@oloo.com",
                    Department = Enums.Dept.Payroll
                },
                new Employee
                {
                    Id = 5,
                    Name = "Krishna",
                    Email = "krishna@gmail.com",
                    Department = Enums.Dept.QualityAssurance
                },

                new Employee
                {
                    Id = 6,
                    Name = "Jane",
                    Email = "jane@gmail.com",
                    Department = Enums.Dept.HR
                }

              );
        }
    }
}
