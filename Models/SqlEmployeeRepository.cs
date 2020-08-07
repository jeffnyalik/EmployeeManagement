using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public SqlEmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
            
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
            
        }

        public IEnumerable<Employee> getAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var employees = _context.Employees.Attach(employee);
            employees.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }
    }
}
